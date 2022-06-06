using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using CKMates.DAC;
using PX.Data;
using PX.Data.BQL.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Objects.CR;

namespace CKMates.Graph
{
    public class LUMUnsubscribeProcess : PXGraph<LUMUnsubscribeProcess>
    {
        public PXSave<LUMAmazonS3Preference> Save;
        public PXCancel<LUMAmazonS3Preference> Cancel;
        public PXProcessing<LUMAmazonS3Preference> S3FileList;

        public LUMUnsubscribeProcess()
        {
            this.S3FileList.SetProcessDelegate(delegate (List<LUMAmazonS3Preference> list)
            {
                GoProcessing(list);
            });
        }

        #region Method
        /// <summary> 非同步執行 </summary>
        public static void GoProcessing(List<LUMAmazonS3Preference> list)
        {
            var baseGraph = CreateInstance<LUMUnsubscribeProcess>();
            baseGraph.UpdateUnsubscribeList(true);
        }

        /// <summary> 更新不訂閱清單 </summary>
        public virtual void UpdateUnsubscribeList(bool isProcess)
        {
            try
            {
                var preference = SelectFrom<LUMAmazonS3Preference>.View.SelectSingleBound(new PXGraph(), null)?.TopFirst;
                if (preference == null)
                    throw new Exception("Amazon S3 Prefernce is null!!");
                // Specify your bucket region (an example region is shown).
                RegionEndpoint bucketRegion = RegionEndpoint.APNortheast1;
                IAmazonS3 client;
                AWSCredentials credential = new Amazon.Runtime.BasicAWSCredentials(preference.AccessKey, preference.SecretKey);
                client = new AmazonS3Client(credential, bucketRegion);
                var unsubscribeString = ReadObjectDataAsync(preference.BucketName, preference.KeyName, client);
                if (string.IsNullOrEmpty(unsubscribeString))
                    throw new Exception("Usubscribe List Is Empty, Please check S3 File");
                // 字串切割
                char[] delims = new[] { '\r', '\n' };
                List<string> unsubscribeEmailList = unsubscribeString.Replace("\"", "").Split(delims, StringSplitOptions.RemoveEmptyEntries).ToList();
                unsubscribeEmailList.RemoveAt(0);
                // 現行系統是noEmail的
                var isNoEmailList = SelectFrom<Contact>.Where<Contact.noEMail.IsEqual<True>>.View.Select(new PXGraph()).RowCast<Contact>().ToList();
                using (PXTransactionScope sc = new PXTransactionScope())
                {
                    // 將原本No-Email改成訂閱
                    foreach (var subscribeEmail in isNoEmailList.Select(x => x.EMail).Except(unsubscribeEmailList))
                    {
                        PXDatabase.Update<Contact>(
                            new PXDataFieldAssign<Contact.noEMail>(false),
                            new PXDataFieldRestrict<Contact.eMail>(subscribeEmail));
                    }
                    foreach (var unsubscribeEmail in unsubscribeEmailList)
                    {
                        PXDatabase.Update<Contact>(
                           new PXDataFieldAssign<Contact.noEMail>(true),
                           new PXDataFieldRestrict<Contact.eMail>(unsubscribeEmail));
                    }
                    sc.Complete();
                }
            }
            catch (Exception ex)
            {
                if (isProcess)
                    PXProcessing.SetError(ex.Message);
                else
                    throw ex;
            }
        }
        /// <summary> 讀取Amazon S3 Bucket File 內容 </summary>
        public string ReadObjectDataAsync(string bucketName, string keyName, IAmazonS3 client)
        {
            string responseBody = "";
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };
                using (GetObjectResponse response = client.GetObject(request))
                using (Stream responseStream = response.ResponseStream)
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string title = response.Metadata["x-amz-meta-title"]; // Assume you have "title" as medata added to the object.
                    string contentType = response.Headers["Content-Type"];
                    responseBody = reader.ReadToEnd(); // Now you process the response body.
                }
            }
            catch (AmazonS3Exception e)
            {
                // If bucket or object does not exist
                throw new Exception($"Error encountered ***. Message:'{e.Message}' when reading object");
            }
            catch (Exception e)
            {
                throw new Exception($"Unknown encountered on server. Message:'{e.Message}' when reading object");
            }
            return responseBody;
        }

        #endregion
    }
}

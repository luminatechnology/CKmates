using System;
using PX.Data;

namespace CKMates.DAC
{
    [Serializable]
    [PXCacheName("LUMAmazonS3Preference")]
    public class LUMAmazonS3Preference : IBqlTable
    {
        #region Selected
        [PXBool()]
        [PXUIField(DisplayName = "Selected")]
        public virtual bool? Selected { get; set; }
        public abstract class selected : PX.Data.BQL.BqlBool.Field<selected> { }
        #endregion

        #region BucketName
        [PXDBString(200, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Bucket Name")]
        public virtual string BucketName { get; set; }
        public abstract class bucketName : PX.Data.BQL.BqlString.Field<bucketName> { }
        #endregion

        #region KeyName
        [PXDBString(200, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Key Name")]
        public virtual string KeyName { get; set; }
        public abstract class keyName : PX.Data.BQL.BqlString.Field<keyName> { }
        #endregion

        #region AccessKey
        [PXRSACryptString(1000, IsUnicode = true)]
        [PXUIField(DisplayName = "Access Key")]
        public virtual string AccessKey { get; set; }
        public abstract class accessKey : PX.Data.BQL.BqlString.Field<accessKey> { }
        #endregion

        #region SecretKey
        [PXRSACryptString(1000, IsUnicode = true)]
        [PXUIField(DisplayName = "Secret Key")]
        public virtual string SecretKey { get; set; }
        public abstract class secretKey : PX.Data.BQL.BqlString.Field<secretKey> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion
    }
}
using CKMates.DAC;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Export.Excel.Core;
using PX.Objects.CR;
using PX.SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKMates.Graph
{
    public class LUMExportOpportunityToExcelProcess : PXGraph<LUMExportOpportunityToExcelProcess>
    {
        public PXSave<CROpportunity> Save;
        public PXCancel<CROpportunity> Cancel;

        public SelectFrom<CROpportunity>
              .LeftJoin<LUMCompanyTreeMember>.On<CROpportunity.workgroupID.IsEqual<LUMCompanyTreeMember.workGroupID>>
              .LeftJoin<CRAddress>.On<CROpportunity.opportunityAddressID.IsEqual<CRAddress.addressID>>
              .LeftJoin<CRContact>.On<CROpportunity.contactID.IsEqual<CRContact.contactID>>
              .LeftJoin<CROpportunityProbability>.On<CROpportunity.stageID.IsEqual<CROpportunityProbability.stageCode>>
              .View Transactions;

        public IEnumerable transactions()
        {
            Int32 totalrow = 0;
            Int32 startrow = PXView.StartRow;
            PXGenericInqGrph gi = PXGenericInqGrph.CreateInstance("CR3040PL");
            PXResultset<GenericResult> results = gi.Results.Select(PXView.Currents, PXView.Parameters,
                   PXView.Searches, PXView.SortColumns, PXView.Descendings,
                   PXView.Filters, startrow, PXView.MaximumRows, totalrow);
            foreach (GenericResult item in results)
            {
                CROpportunity opportunity = item.Values["CROpportunity"] as CROpportunity;
                CRAddress address = item.Values["CRAddress"] as CRAddress;
                CRContact contact = item.Values["CRContact"] as CRContact;
                CROpportunityProbability probability = item.Values["CROpportunityProbability"] as CROpportunityProbability;
                LUMCompanyTreeMember treeMember = item.Values["LUMCompanyTreeMember"] as LUMCompanyTreeMember;

                var opportunityExt = opportunity.GetExtension<CROpportunityExt>();
                #region UDF
                var UDF_Otype = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "OTYPE"));
                var UDF_PRODHIER = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "PRODHIER"));
                var UDF_AWSSTATUS = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "AWSSTATUS"));
                var UDF_AWSAUTH = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "AWSAUTH"));
                var UDF_AWSNEED = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "AWSNEED"));
                var UDF_AWSFIT = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "AWSFIT"));
                var UDF_AWSCOMP = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "AWSCOMP"));
                var UDF_SOURCE = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "SOURCE"));
                var UDF_BUDGET = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "BUDGET"));
                var UDF_APN = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "APN"));
                var UDF_BOOKDATE = ((PXDateState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "BOOKDATE"));
                var UDF_USECASE = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "USECASE"));
                var UDF_MAINREQ = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "MAINREQ"));
                var UDF_POCAMT = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "POCAMT"));
                var UDF_AWSBD = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "AWSBD"));
                var UDF_AWSID = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "AWSID"));
                var UDF_DEALER = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "DEALER"));
                var UDF_APNID = ((PXStringState)this.Transactions.Cache.GetValueExt(opportunity, PX.Objects.CS.Messages.Attribute + "APNID"));
                #endregion
                #region Set Field value
                if (!string.IsNullOrEmpty((string)UDF_Otype.Value))
                    opportunityExt.UsrOTYPE = UDF_Otype.ValueLabelDic[(string)UDF_Otype.Value];
                opportunityExt.UsrPRODHIER = (string)UDF_PRODHIER.Value;
                if (!string.IsNullOrEmpty((string)UDF_AWSSTATUS.Value))
                    opportunityExt.UsrAWSSTATUS = UDF_AWSSTATUS.ValueLabelDic[(string)UDF_AWSSTATUS.Value];
                opportunityExt.UsrAWSAUTH = (string)UDF_AWSAUTH.Value;
                opportunityExt.UsrAWSNEED = (string)UDF_AWSNEED.Value;
                opportunityExt.UsrAWSFIT = (string)UDF_AWSFIT.Value;
                opportunityExt.UsrAWSCOMP = (string)UDF_AWSCOMP.Value;
                if (!string.IsNullOrEmpty((string)UDF_SOURCE.Value))
                    opportunityExt.UsrSOURCE = UDF_SOURCE.ValueLabelDic[(string)UDF_SOURCE.Value];
                if (!string.IsNullOrEmpty((string)UDF_BUDGET.Value))
                    opportunityExt.UsrBUDGET = UDF_BUDGET.ValueLabelDic[(string)UDF_BUDGET.Value];
                if (!string.IsNullOrEmpty((string)UDF_APN.Value))
                    opportunityExt.UsrAPN = UDF_APN.ValueLabelDic[(string)UDF_APN.Value];
                opportunityExt.UsrBOOKDATE = (DateTime?)UDF_BOOKDATE.Value;
                if (!string.IsNullOrEmpty((string)UDF_USECASE.Value))
                    opportunityExt.UsrUSECASE = UDF_USECASE.ValueLabelDic[(string)UDF_USECASE.Value];
                if (!string.IsNullOrEmpty((string)UDF_MAINREQ.Value))
                    opportunityExt.UsrMAINREQ = UDF_MAINREQ.ValueLabelDic[(string)UDF_MAINREQ.Value];
                opportunityExt.UsrPOCAMT = (string)UDF_POCAMT.Value;
                opportunityExt.UsrAWSBD = (string)UDF_AWSBD.Value;
                opportunityExt.UsrAWSID = (string)UDF_AWSID.Value;
                opportunityExt.UsrDEALER = (string)UDF_DEALER.Value;
                opportunityExt.UsrAPNID = (string)UDF_APNID.Value;
                opportunityExt.UsrCalculateCuryAmount = opportunity.Status == "W" ? opportunity?.CuryRawAmount :
                                                        opportunity.Status != "L" ? probability?.Probability * opportunity?.CuryRawAmount / 100 : 0;
                opportunityExt.UsrCalculateTWDAmount = opportunity.Status == "W" ? opportunity?.CuryAmount :
                                                        opportunity.Status != "L" ? probability?.Probability * opportunity?.CuryAmount / 100 : 0;
                #endregion
                yield return new PXResult<CROpportunity, CRAddress, CRContact, LUMCompanyTreeMember>(opportunity, address, contact, treeMember);
            }
        }

        #region Action
        public PXAction<CROpportunity> exportGridToExcel;
        [PXUIField(DisplayName = "Export to Excel", MapEnableRights = PXCacheRights.Select)]
        [PXButton(Tooltip = "Export to Excel")]
        protected virtual void ExportGridToExcel()
        {

            PXLongOperation.StartOperation(this, delegate ()
            {
                var excel = new PX.Export.Excel.Core.Package();
                var sheet = excel.Workbook.Sheets[1];

                int headingRow = 1;
                int gridRow = 2;

                var data = this.Transactions.Select();

                // Heading Information
                #region Header
                sheet.Add(headingRow, 1, PXLocalizer.Localize("Opportunity ID"));
                sheet.Add(headingRow, 2, "專案名稱");
                sheet.Add(headingRow, 3, "商務帳戶");
                sheet.Add(headingRow, 4, "總計");
                sheet.Add(headingRow, 5, "經辦人");
                sheet.Add(headingRow, 6, "工作群組ID");
                sheet.Add(headingRow, 7, "CloseDate");
                sheet.Add(headingRow, 8, "Parentwgid");
                sheet.Add(headingRow, 9, "Rootwgid");
                sheet.Add(headingRow, 10, "狀態");
                sheet.Add(headingRow, 11, "階段");
                sheet.Add(headingRow, 12, "幣別");
                sheet.Add(headingRow, 13, "CuryRawAmount");
                sheet.Add(headingRow, 14, "Amount");
                sheet.Add(headingRow, 15, "ClosingDate");
                sheet.Add(headingRow, 16, "CloseDate");
                sheet.Add(headingRow, 17, "地址行1");
                sheet.Add(headingRow, 18, "地址行2");
                sheet.Add(headingRow, 19, "州(省)名稱");
                sheet.Add(headingRow, 20, "郵遞區號");
                sheet.Add(headingRow, 21, "建立者");
                sheet.Add(headingRow, 22, "CreatedDateTime");
                sheet.Add(headingRow, 23, "最後修改人");
                sheet.Add(headingRow, 24, "最後修正日期");
                sheet.Add(headingRow, 25, "ContactID");
                sheet.Add(headingRow, 26, "名稱");
                sheet.Add(headingRow, 27, "Salutation");
                sheet.Add(headingRow, 28, "電子郵件");
                sheet.Add(headingRow, 29, "網站");
                sheet.Add(headingRow, 30, "電話1");
                sheet.Add(headingRow, 31, "電話1");
                sheet.Add(headingRow, 32, "產品類別");
                sheet.Add(headingRow, 33, "專案屬性");
                sheet.Add(headingRow, 34, "AWS Status");
                sheet.Add(headingRow, 35, "Authority (A)");
                sheet.Add(headingRow, 36, "Needs(N)");
                sheet.Add(headingRow, 37, "Fitness (F)");
                sheet.Add(headingRow, 38, "競爭對手");
                sheet.Add(headingRow, 39, "來源");
                sheet.Add(headingRow, 40, "專案預算");
                sheet.Add(headingRow, 41, "是否要上APN");
                sheet.Add(headingRow, 42, "Booking Date");
                sheet.Add(headingRow, 43, "Use Case");
                sheet.Add(headingRow, 44, "主要需求");
                sheet.Add(headingRow, 45, "POC 申請金額");
                sheet.Add(headingRow, 46, "AWS BD");
                sheet.Add(headingRow, 47, "AWS ID");
                sheet.Add(headingRow, 48, "經銷商");
                sheet.Add(headingRow, 49, "APN ID");
                sheet.Add(headingRow, 50, "原幣加權金額");
                sheet.Add(headingRow, 51, "台幣加權金額");
                #endregion
                int totalColumn = 52;
                // adjust column width
                for (int i = 0; i <= totalColumn; i++)
                    sheet.SetColumnWidth(i, 35);

                foreach (PXResult<CROpportunity, CRAddress, CRContact, LUMCompanyTreeMember> item in data)
                {
                    var tran = (CROpportunity)item;
                    var companyTree = (LUMCompanyTreeMember)item;
                    var address = (CRAddress)item;
                    var contact = (CRContact)item;
                    var acctInfo = BAccount.PK.Find(this, tran.BAccountID);
                    var ownerInfo = SelectFrom<BAccount>
                                   .Where<BAccount.defContactID.IsEqual<P.AsInt>>
                                   .View.Select(this, tran?.OwnerID).TopFirst;
                    #region data
                    sheet.Add(gridRow, 1, tran.OpportunityID, -984833);
                    sheet.AddHyperlink(gridRow, 1, $"https://cloudcrm.ckmates.com/CRM/(W(1945))/Main?CompanyID=CRM&ScreenId=CR304000&OpportunityID={tran.OpportunityID}");
                    sheet.AddFill(gridRow, 1, gridRow, 1,
                                PX.Export.Excel.Core.Utils.RgbToColor(-984833),
                                PX.Export.Excel.Core.Utils.RgbToColor(-984833));
                    sheet.Add(gridRow, 2, tran?.Subject);
                    sheet.Add(gridRow, 3, acctInfo?.AcctCD);
                    sheet.Add(gridRow, 4, tran?.CuryProductsAmount?.ToString());
                    sheet.Add(gridRow, 5, ownerInfo?.AcctName);
                    sheet.Add(gridRow, 6, tran?.WorkgroupID?.ToString());
                    sheet.Add(gridRow, 7, tran?.CloseDate?.ToString("yyyy/MM/dd"));
                    sheet.Add(gridRow, 8, companyTree?.Parentwgid?.ToString());
                    sheet.Add(gridRow, 9, companyTree?.Rootwgid?.ToString());
                    sheet.Add(gridRow, 10, tran?.Status);
                    sheet.Add(gridRow, 11, tran?.StageID);
                    sheet.Add(gridRow, 12, tran?.CuryID);
                    sheet.Add(gridRow, 13, tran?.CuryRawAmount?.ToString());
                    sheet.Add(gridRow, 14, tran?.Amount?.ToString());
                    sheet.Add(gridRow, 15, tran?.ClosingDate?.ToString());
                    sheet.Add(gridRow, 16, tran?.CloseDate?.ToString());
                    sheet.Add(gridRow, 17, address?.AddressLine1);
                    sheet.Add(gridRow, 18, address?.AddressLine2);
                    sheet.Add(gridRow, 19, address?.State);
                    sheet.Add(gridRow, 20, address?.PostalCode);
                    sheet.Add(gridRow, 21, Users.PK.Find(this, tran?.CreatedByID)?.Username);
                    sheet.Add(gridRow, 22, tran?.CreatedDateTime?.ToString("yyyy/MM/dd"));
                    sheet.Add(gridRow, 23, Users.PK.Find(this, tran?.LastModifiedByID)?.Username);
                    sheet.Add(gridRow, 24, tran.LastModifiedDateTime?.ToString("yyyy/MM/dd"));
                    sheet.Add(gridRow, 25, contact?.ContactID?.ToString());
                    sheet.Add(gridRow, 26, contact?.DisplayName);
                    sheet.Add(gridRow, 27, contact?.Salutation);
                    sheet.Add(gridRow, 28, contact?.Email);
                    sheet.Add(gridRow, 29, contact?.WebSite);
                    sheet.Add(gridRow, 30, contact?.Phone1Type);
                    sheet.Add(gridRow, 31, contact?.Phone1);
                    sheet.Add(gridRow, 32, tran?.GetExtension<CROpportunityExt>().UsrPRODHIER);
                    sheet.Add(gridRow, 33, tran?.GetExtension<CROpportunityExt>().UsrOTYPE);
                    sheet.Add(gridRow, 34, tran?.GetExtension<CROpportunityExt>().UsrAWSSTATUS);
                    sheet.Add(gridRow, 35, tran?.GetExtension<CROpportunityExt>().UsrAWSAUTH);
                    sheet.Add(gridRow, 36, tran?.GetExtension<CROpportunityExt>().UsrAWSNEED);
                    sheet.Add(gridRow, 37, tran?.GetExtension<CROpportunityExt>().UsrAWSFIT);
                    sheet.Add(gridRow, 38, tran?.GetExtension<CROpportunityExt>().UsrAWSCOMP);
                    sheet.Add(gridRow, 39, tran?.GetExtension<CROpportunityExt>().UsrSOURCE);
                    sheet.Add(gridRow, 40, tran?.GetExtension<CROpportunityExt>().UsrBUDGET);
                    sheet.Add(gridRow, 41, tran?.GetExtension<CROpportunityExt>().UsrAPN);
                    sheet.Add(gridRow, 42, tran?.GetExtension<CROpportunityExt>().UsrBOOKDATE?.ToString("yyyy/MM/dd"));
                    sheet.Add(gridRow, 43, tran?.GetExtension<CROpportunityExt>().UsrUSECASE);
                    sheet.Add(gridRow, 44, tran?.GetExtension<CROpportunityExt>().UsrMAINREQ);
                    sheet.Add(gridRow, 45, tran?.GetExtension<CROpportunityExt>().UsrPOCAMT);
                    sheet.Add(gridRow, 46, tran?.GetExtension<CROpportunityExt>().UsrAWSBD);
                    sheet.Add(gridRow, 47, tran?.GetExtension<CROpportunityExt>().UsrAWSID);
                    sheet.Add(gridRow, 48, tran?.GetExtension<CROpportunityExt>().UsrDEALER);
                    sheet.Add(gridRow, 49, tran?.GetExtension<CROpportunityExt>().UsrAPNID);
                    sheet.Add(gridRow, 50, tran?.GetExtension<CROpportunityExt>().UsrCalculateCuryAmount?.ToString());
                    sheet.Add(gridRow, 51, tran?.GetExtension<CROpportunityExt>().UsrCalculateTWDAmount?.ToString());
                    #endregion


                    gridRow++;
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    excel.Write(stream);
                    string path = $"CROpportunity_{DateTime.Now.ToString()}.xlsx";
                    var info = new PX.SM.FileInfo(path, null, stream.ToArray());
                    throw new PXRedirectToFileException(info, true);
                }
            });

        }
        #endregion

    }
}

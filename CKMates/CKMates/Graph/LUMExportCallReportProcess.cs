using CKMates.DAC;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKMates.Graph
{
    public class LUMExportCallReportProcess : PXGraph<LUMExportCallReportProcess>
    {
        public PXSave<CRActivity> Save;
        public PXCancel<CRActivity> Cancel;

        public SelectFrom<CRActivity>
              .LeftJoin<LUMCompanyTreeMember>.On<CRActivity.ownerID.IsEqual<LUMCompanyTreeMember.contactID>>
              .LeftJoin<CROpportunity>.On<CRActivity.refNoteID.IsEqual<CROpportunity.noteID>>
              .LeftJoin<BAccount>.On<CRActivity.bAccountID.IsEqual<BAccount.bAccountID>>
              .View Transactions;

        public IEnumerable transactions()
        {
            Int32 totalrow = 0;
            Int32 startrow = PXView.StartRow;
            PXGenericInqGrph gi = PXGenericInqGrph.CreateInstance("GI000018");
            PXResultset<GenericResult> results = gi.Results.Select(PXView.Currents, PXView.Parameters,
                   PXView.Searches, PXView.SortColumns, PXView.Descendings,
                   PXView.Filters, startrow, PXView.MaximumRows, totalrow);
            foreach (GenericResult item in results)
            {
                CROpportunity opportunity = item.Values["CROpportunity"] as CROpportunity;
                CRActivity activity = item.Values["CRActivity"] as CRActivity;
                BAccount account = item.Values["BAccount"] as BAccount;
                LUMCompanyTreeMember treeMember = item.Values["LUMCompanyTreeMember"] as LUMCompanyTreeMember;

                yield return new PXResult<CRActivity, LUMCompanyTreeMember, CROpportunity, BAccount>(activity, treeMember, opportunity, account);
            }
        }

        #region Action
        public PXAction<CRActivity> exportGridToExcel;
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

                // Heading Information
                #region Header
                sheet.Add(headingRow, 1, PXLocalizer.Localize("Opportunity ID"));
                sheet.Add(headingRow, 2, "專案名稱");
                sheet.Add(headingRow, 3, "概要");
                sheet.Add(headingRow, 4, "開始日期");
                sheet.Add(headingRow, 5, "星期幾");
                sheet.Add(headingRow, 6, "經辦人");
                sheet.Add(headingRow, 7, "工作群組ID");
                sheet.Add(headingRow, 8, "Parentwgid");
                sheet.Add(headingRow, 9, "Rootwgid");
                sheet.Add(headingRow, 10, "關聯文件");
                sheet.Add(headingRow, 11, "概要");
                sheet.Add(headingRow, 12, "帳戶名稱");
                #endregion
                int totalColumn = 12;
                // adjust column width
                for (int i = 0; i <= totalColumn; i++)
                    sheet.SetColumnWidth(i, 35);

                foreach (PXResult<CRActivity, LUMCompanyTreeMember, CROpportunity, BAccount> item in this.Transactions.Select())
                {
                    var tran = (CROpportunity)item;
                    var companyTree = (LUMCompanyTreeMember)item;
                    var activity = (CRActivity)item;
                    var account = (BAccount)item;
                    var acctInfo = BAccount.PK.Find(this, tran.BAccountID);
                    var ownerInfo = SelectFrom<BAccount>
                                   .Where<BAccount.defContactID.IsEqual<P.AsInt>>
                                   .View.Select(this,activity?.OwnerID).TopFirst;
                    #region data
                    sheet.Add(gridRow, 1, tran.OpportunityID, -984833);
                    sheet.AddHyperlink(gridRow, 1, $"https://cloudcrm.ckmates.com/CRM/(W(1945))/Main?CompanyID=CRM&ScreenId=CR304000&OpportunityID={tran.OpportunityID}");
                    sheet.AddFill(gridRow, 1, gridRow, 1,
                                PX.Export.Excel.Core.Utils.RgbToColor(-984833),
                                PX.Export.Excel.Core.Utils.RgbToColor(-984833));

                    sheet.Add(gridRow, 2, activity?.Type);
                    sheet.Add(gridRow, 3, activity?.Subject);
                    sheet.Add(gridRow, 4, activity?.StartDate?.ToString());
                    sheet.Add(gridRow, 5, activity?.DayOfWeek?.ToString());
                    sheet.Add(gridRow, 6, ownerInfo?.AcctName?.ToString());
                    sheet.Add(gridRow, 7, companyTree?.WorkGroupID?.ToString());
                    sheet.Add(gridRow, 8, companyTree?.Parentwgid?.ToString());
                    sheet.Add(gridRow, 9, companyTree?.Rootwgid?.ToString());
                    sheet.Add(gridRow, 10, activity?.Source);
                    sheet.Add(gridRow, 11, activity?.Subject);
                    sheet.Add(gridRow, 11, account?.AcctName);
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

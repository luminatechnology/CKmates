using CKMates.DAC;
using PX.Data;
using PX.Data.BQL.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKMates.Graph
{
    public class LUMUpdateSalesRollingForecastProcess : PXGraph<LUMUpdateSalesRollingForecastProcess>
    {
        public PXSave<LUMSalesRollingForecastResult> Save;
        public PXCancel<LUMSalesRollingForecastResult> Cancel;

        public PXProcessing<LUMSalesRollingForecastResult> TempTableResult;
        public LUMUpdateSalesRollingForecastProcess()
        {
            //TempTableResult.SetProcessVisible(false);
            TempTableResult.SetProcessDelegate(delegate (List<LUMSalesRollingForecastResult> list)
            {
                GoProcessing();
            });
            // Initial Data
            if (this.TempTableResult.Select().Count == 0)
                InitialData();
        }

        #region Method

        public static void GoProcessing()
        {
            var baseGraph = CreateInstance<LUMUpdateSalesRollingForecastProcess>();
            baseGraph.InsertIntoTempTable(baseGraph);
        }

        /// <summary> 將Rolling Result into Temptable </summary>
        public virtual void InsertIntoTempTable(LUMUpdateSalesRollingForecastProcess baseGraph)
        {
            try
            {
                using (new PXCommandScope(300))
                {
                    using (PXTransactionScope sc = new PXTransactionScope())
                    {
                        var result = SelectFrom<v_GI_RollingForcastProcessResult>.View.Select(baseGraph).RowCast<v_GI_RollingForcastProcessResult>();
                        // Delete all temptable data
                        PXDatabase.Delete<LUMSalesRollingForecastResult>();
                        baseGraph.TempTableResult.Cache.Clear();
                        // Get SQL View Result(GI)
                        foreach (var item in result)
                        {
                            var temp = baseGraph.TempTableResult.Cache.CreateInstance() as LUMSalesRollingForecastResult;
                            temp.ForecastType = item.ForecastType;
                            temp.FinYear = item.FinYear;
                            temp.WorkgroupID = item.WorkGroupID;
                            temp.SubFinperiodID = item.SubFinPeriodID;
                            temp.Amount = item.Amount;
                            temp.OrderSeq = item.OrderSeq;
                            baseGraph.TempTableResult.Insert(temp);
                        }
                        baseGraph.Actions.PressSave();
                        sc.Complete();
                    }
                }
            }
            catch (PXOuterException ex)
            {
                PXProcessing.SetError(ex.InnerMessages[0]);
            }
            catch (Exception ex)
            {
                PXProcessing.SetError(ex.Message);
            }
        }


        /// <summary> 產生一筆固定資料 </summary>
        public virtual void InitialData()
        {
            string screenIDWODot = this.Accessinfo.ScreenID.ToString().Replace(".", "");

            PXDatabase.Insert<LUMSalesRollingForecastResult>(
                                 new PXDataFieldAssign<LUMSalesRollingForecastResult.forecastType>("Default"));
        }

        #endregion
    }
}

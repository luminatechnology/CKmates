using CKMates.DAC;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using PX.TM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PX.Data.PXAccess;

namespace CKMates.Graph
{
    public class LUMForecastAdjustmentMaint : PXGraph<LUMForecastAdjustmentMaint>
    {
        public PXSave<ForecastFilter> Save;
        public PXCancel<ForecastFilter> Cancel;

        public PXFilter<ForecastFilter> Filter;
        public SelectFrom<LUMManualForecastAdjustment>
               .Where<LUMManualForecastAdjustment.workgroupID.IsEqual<ForecastFilter.workgroupID.FromCurrent>
                 .And<LUMManualForecastAdjustment.year.IsEqual<ForecastFilter.year.FromCurrent>>>.View Transactions;

        public SelectFrom<v_RollingForcastProcessResult>
               .Where<v_RollingForcastProcessResult.workGroupID.IsEqual<ForecastFilter.workgroupID.FromCurrent>
                 .And<v_RollingForcastProcessResult.finYear.IsEqual<ForecastFilter.year.FromCurrent>>>
               .OrderBy<Asc<v_RollingForcastProcessResult.orderSeq>>.View RollingResult;


        public IEnumerable transactions()
        {
            var filter = this.Filter.Current;
            PXView select = new PXView(this, false, Transactions.View.BqlSelect);
            Int32 totalrow = 0;
            Int32 startrow = PXView.StartRow;
            List<object> result = select.Select(PXView.Currents, PXView.Parameters,
                   PXView.Searches, PXView.SortColumns, PXView.Descendings,
                   PXView.Filters, ref startrow, PXView.MaximumRows, ref totalrow);
            PXView.StartRow = 0;
            if (result.Count == 0 && filter.WorkgroupID.HasValue && filter.Year.HasValue)
            {
                var trans = this.Transactions.Cache.CreateInstance() as LUMManualForecastAdjustment;
                trans.WorkgroupID = this.Filter.Current.WorkgroupID;
                trans.Year = this.Filter.Current.Year;
                result.Add(trans);
                this.Transactions.Insert(trans);
            }
            return result;
        }

        public IEnumerable rollingResult()
        {
            PXView select = new PXView(this, false, RollingResult.View.BqlSelect);
            Int32 totalrow = 0;
            Int32 startrow = PXView.StartRow;
            List<object> result = select.Select(PXView.Currents, PXView.Parameters,
                   PXView.Searches, PXView.SortColumns, PXView.Descendings,
                   PXView.Filters, ref startrow, PXView.MaximumRows, ref totalrow);
            PXView.StartRow = 0;
            this.RollingResult.View.Clear();
            foreach (v_RollingForcastProcessResult row in result)
            {
                if (row.ForecastType == "當月達成率" || row.ForecastType == "當月累計達成率")
                {
                    #region Setting Display
                    row.DisplayPeriod01 = $"{Math.Round((row.Period01 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod02 = $"{Math.Round((row.Period02 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod03 = $"{Math.Round((row.Period03 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod04 = $"{Math.Round((row.Period04 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod05 = $"{Math.Round((row.Period05 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod06 = $"{Math.Round((row.Period06 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod07 = $"{Math.Round((row.Period07 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod08 = $"{Math.Round((row.Period08 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod09 = $"{Math.Round((row.Period09 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod10 = $"{Math.Round((row.Period10 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod11 = $"{Math.Round((row.Period11 ?? 0) * 100, 2)}%";
                    row.DisplayPeriod12 = $"{Math.Round((row.Period12 ?? 0) * 100, 2)}%";
                    #endregion
                }
                else
                {
                    #region Setting Display
                    row.DisplayPeriod01 = row.Period01.HasValue ? Math.Round(row.Period01.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod02 = row.Period02.HasValue ? Math.Round(row.Period02.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod03 = row.Period03.HasValue ? Math.Round(row.Period03.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod04 = row.Period04.HasValue ? Math.Round(row.Period04.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod05 = row.Period05.HasValue ? Math.Round(row.Period05.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod06 = row.Period06.HasValue ? Math.Round(row.Period06.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod07 = row.Period07.HasValue ? Math.Round(row.Period07.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod08 = row.Period08.HasValue ? Math.Round(row.Period08.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod09 = row.Period09.HasValue ? Math.Round(row.Period09.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod10 = row.Period10.HasValue ? Math.Round(row.Period10.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod11 = row.Period11.HasValue ? Math.Round(row.Period11.Value, 0).ToString("N0") : string.Empty;
                    row.DisplayPeriod12 = row.Period12.HasValue ? Math.Round(row.Period12.Value, 0).ToString("N0") : string.Empty;
                    #endregion
                }
            }
            return result;
        }

        #region Event

        public virtual void _(Events.FieldDefaulting<LUMManualForecastAdjustment.workgroupID> e)
        {
            if (this.Filter.Current.WorkgroupID.HasValue)
                e.NewValue = this.Filter.Current.WorkgroupID;
        }

        public virtual void _(Events.FieldDefaulting<LUMManualForecastAdjustment.year> e)
        {
            if (this.Filter.Current.Year.HasValue)
                e.NewValue = this.Filter.Current.Year;
        }

        #endregion

        [Serializable]
        public class ForecastFilter : IBqlTable
        {
            #region WorkgroupID
            [PXDBInt()]
            [PXSelector(typeof(SelectFrom<EPCompanyTree>
                          .InnerJoin<EPCompanyTreeH>.On<EPCompanyTree.workGroupID.IsEqual<EPCompanyTreeH.workGroupID>>
                          .InnerJoin<LUMCompanyTreeMember>.On<EPCompanyTreeH.parentWGID.IsEqual<LUMCompanyTreeMember.workGroupID>>
                          .InnerJoin<BAccount2>.On<LUMCompanyTreeMember.contactID.IsEqual<BAccount2.defContactID>>
                          .InnerJoin<EPEmployee>.On<BAccount2.bAccountID.IsEqual<EPEmployee.bAccountID>>
                          .Where<EPEmployee.userID.IsEqual<AccessInfo.userID.FromCurrent>>
                          .SearchFor<EPCompanyTree.workGroupID>),
                        typeof(EPCompanyTree.description),
                        SubstituteKey = typeof(EPCompanyTree.description))]
            [PXUIField(DisplayName = "Workgroup ID")]
            public virtual int? WorkgroupID { get; set; }
            public abstract class workgroupID : PX.Data.BQL.BqlInt.Field<workgroupID> { }
            #endregion

            #region Year
            [PXDBInt()]
            [PXUIField(DisplayName = "Year")]
            public virtual int? Year { get; set; }
            public abstract class year : PX.Data.BQL.BqlInt.Field<year> { }
            #endregion
        }
    }
}

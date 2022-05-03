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
                    row.DisplayPeriod01 = $"{row.Period01 * 100}%";
                    row.DisplayPeriod02 = $"{row.Period02 * 100}%";
                    row.DisplayPeriod03 = $"{row.Period03 * 100}%";
                    row.DisplayPeriod04 = $"{row.Period04 * 100}%";
                    row.DisplayPeriod05 = $"{row.Period05 * 100}%";
                    row.DisplayPeriod06 = $"{row.Period06 * 100}%";
                    row.DisplayPeriod07 = $"{row.Period07 * 100}%";
                    row.DisplayPeriod08 = $"{row.Period08 * 100}%";
                    row.DisplayPeriod09 = $"{row.Period09 * 100}%";
                    row.DisplayPeriod10 = $"{row.Period10 * 100}%";
                    row.DisplayPeriod11 = $"{row.Period11 * 100}%";
                    row.DisplayPeriod12 = $"{row.Period12 * 100}%";
                    #endregion
                }
                else
                {
                    #region Setting Display
                    row.DisplayPeriod01 = row.Period01?.ToString();
                    row.DisplayPeriod02 = row.Period02?.ToString();
                    row.DisplayPeriod03 = row.Period03?.ToString();
                    row.DisplayPeriod04 = row.Period04?.ToString();
                    row.DisplayPeriod05 = row.Period05?.ToString();
                    row.DisplayPeriod06 = row.Period06?.ToString();
                    row.DisplayPeriod07 = row.Period07?.ToString();
                    row.DisplayPeriod08 = row.Period08?.ToString();
                    row.DisplayPeriod09 = row.Period09?.ToString();
                    row.DisplayPeriod10 = row.Period10?.ToString();
                    row.DisplayPeriod11 = row.Period11?.ToString();
                    row.DisplayPeriod12 = row.Period12?.ToString();
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

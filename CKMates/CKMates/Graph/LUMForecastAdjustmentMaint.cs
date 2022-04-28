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
                          .InnerJoin<EPCompanyTreeMember>.On<EPCompanyTreeMember.workGroupID.IsEqual<EPCompanyTree.workGroupID>>
                          .InnerJoin<BAccount2>.On<EPCompanyTreeMember.contactID.IsEqual<BAccount2.defContactID>>
                          .InnerJoin<EPEmployee>.On<BAccount2.bAccountID.IsEqual<EPEmployee.bAccountID>>
                          .Where<EPEmployee.userID.IsEqual<AccessInfo.userID.FromCurrent>>
                          .SearchFor<EPCompanyTree.workGroupID>),
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

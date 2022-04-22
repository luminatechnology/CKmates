using CKMates.DAC;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using PX.TM;
using System;
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

using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using PX.TM;
using static PX.Data.PXAccess;

namespace CKMates
{
    [Serializable]
    [PXCacheName("LUMSalesRollingForecastResult")]
    public class LUMSalesRollingForecastResult : IBqlTable
    {
        #region Selected
        [PXBool()]
        [PXUIField(DisplayName = "Selected")]
        public virtual bool? Selected { get; set; }
        public abstract class selected : PX.Data.BQL.BqlBool.Field<selected> { }
        #endregion

        #region ForecastType
        [PXDBString(100, IsUnicode = true, InputMask = "", IsKey = true)]
        [PXUIField(DisplayName = "Forecast Type")]
        public virtual string ForecastType { get; set; }
        public abstract class forecastType : PX.Data.BQL.BqlString.Field<forecastType> { }
        #endregion

        #region WorkgroupID
        [PXDBInt(IsKey = true)]
        [PXSelector(typeof(SelectFrom<EPCompanyTree>
                          .InnerJoin<EPCompanyTreeMember>.On<EPCompanyTreeMember.workGroupID.IsEqual<EPCompanyTree.workGroupID>>
                          .InnerJoin<BAccount2>.On<EPCompanyTreeMember.contactID.IsEqual<BAccount2.defContactID>>
                          .InnerJoin<EPEmployee>.On<BAccount2.bAccountID.IsEqual<EPEmployee.bAccountID>>
                          .SearchFor<EPCompanyTree.workGroupID>),
                    SubstituteKey = typeof(EPCompanyTree.description))]
        [PXUIField(DisplayName = "Workgroup ID")]
        public virtual int? WorkgroupID { get; set; }
        public abstract class workgroupID : PX.Data.BQL.BqlInt.Field<workgroupID> { }
        #endregion

        #region FinYear
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Fin Year")]
        public virtual int? FinYear { get; set; }
        public abstract class finYear : PX.Data.BQL.BqlInt.Field<finYear> { }
        #endregion

        #region SubFinperiodID
        [PXDBDate(IsKey = true)]
        [PXUIField(DisplayName = "Sub Finperiod ID")]
        public virtual DateTime? SubFinperiodID { get; set; }
        public abstract class subFinperiodID : PX.Data.BQL.BqlDateTime.Field<subFinperiodID> { }
        #endregion

        #region Amount
        [PXDBDecimal()]
        [PXUIField(DisplayName = "Amount")]
        public virtual Decimal? Amount { get; set; }
        public abstract class amount : PX.Data.BQL.BqlDecimal.Field<amount> { }
        #endregion

        #region OrderSeq
        [PXDBInt()]
        [PXUIField(DisplayName = "Order Seq")]
        public virtual int? OrderSeq { get; set; }
        public abstract class orderSeq : PX.Data.BQL.BqlInt.Field<orderSeq> { }
        #endregion

    }
}
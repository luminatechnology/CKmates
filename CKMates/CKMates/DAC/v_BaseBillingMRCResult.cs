using System;
using PX.Data;

namespace CKMates.DAC
{
    [Serializable]
    [PXCacheName("v_BaseBillingMRCResult")]
    public class v_BaseBillingMRCResult : IBqlTable
    {
        #region ForecastType
        [PXDBString(11, InputMask = "", IsKey = true)]
        [PXUIField(DisplayName = "Forecast Type")]
        public virtual string ForecastType { get; set; }
        public abstract class forecastType : PX.Data.BQL.BqlString.Field<forecastType> { }
        #endregion

        #region WorkGroupID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Work Group ID")]
        public virtual int? WorkGroupID { get; set; }
        public abstract class workGroupID : PX.Data.BQL.BqlInt.Field<workGroupID> { }
        #endregion

        #region FinYear
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Fin Year")]
        public virtual int? FinYear { get; set; }
        public abstract class finYear : PX.Data.BQL.BqlInt.Field<finYear> { }
        #endregion

        #region SubFinPeriodID
        [PXDBString(8, InputMask = "", IsKey = true)]
        [PXUIField(DisplayName = "Sub Fin Period ID")]
        public virtual string SubFinPeriodID { get; set; }
        public abstract class subFinPeriodID : PX.Data.BQL.BqlString.Field<subFinPeriodID> { }
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
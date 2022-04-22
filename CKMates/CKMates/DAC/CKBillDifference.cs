using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Data.EP;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.Objects.AR;
using PX.Objects.AR.Standalone;
using PX.Objects.CR;

namespace CKMatesCRM.DAC
{
    [Serializable]
    [PXCacheName("CKBillDifference")]
    public class CKBillDifference : IBqlTable
    {
        #region Date
        [PXDBDate()]
        [PXUIField(DisplayName = "Date")]
        public virtual DateTime? Date { get; set; }
        public abstract class date : PX.Data.BQL.BqlDateTime.Field<date> { }
        #endregion

        #region CustomerID
        [PXDBInt()]
        [PXUIField(DisplayName = "Customer ID")]
        [PXSelector(typeof(Search<BAccount.bAccountID>),
                typeof(BAccount.acctCD),
                typeof(BAccount.acctName),
                DescriptionField = typeof(BAccount.acctName),
                SubstituteKey = typeof(BAccount.acctCD))]
        public virtual int? CustomerID { get; set; }
        public abstract class customerID : PX.Data.BQL.BqlInt.Field<customerID> { }
        #endregion

        #region BillingAmt
        [PXDBDecimal(0)]
        [PXUIField(DisplayName = "Billing Amt")]
        public virtual Decimal? BillingAmt { get; set; }
        public abstract class billingAmt : PX.Data.BQL.BqlDecimal.Field<billingAmt> { }
        #endregion

        #region PreBillingAmt
        [PXDBDecimal(0)]
        [PXUIField(DisplayName = "Pre Billing Amt")]
        public virtual Decimal? PreBillingAmt { get; set; }
        public abstract class preBillingAmt : PX.Data.BQL.BqlDecimal.Field<preBillingAmt> { }
        #endregion
    }
}
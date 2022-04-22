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
    [PXCacheName("CKARRDetail")]
    public class CKARRDetail : IBqlTable
    {
        #region BAccountID
        [PXDBInt()]
        [PXUIField(DisplayName = "BAccount ID")]
        [PXSelector(typeof(Search<BAccount.bAccountID>),
                typeof(BAccount.acctCD),
                typeof(BAccount.acctName),
                DescriptionField = typeof(BAccount.acctName),
                SubstituteKey = typeof(BAccount.acctCD))]
        public virtual int? BAccountID { get; set; }
        public abstract class bAccountID : PX.Data.BQL.BqlInt.Field<bAccountID> { }
        #endregion

        #region CampaignSourceID
        [PXDBString(10, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Campaign Source ID")]
        [PXSelector(typeof(CRCampaign.campaignID), DescriptionField = typeof(CRCampaign.campaignName))]
        [PXFieldDescription]
        public virtual string CampaignSourceID { get; set; }
        public abstract class campaignSourceID : PX.Data.BQL.BqlString.Field<campaignSourceID> { }
        #endregion

        #region OpportunityID
        [PXDBString(10, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Opportunity ID")]
        [PXSelector(typeof(Search2<CROpportunity.opportunityID,
          LeftJoin<BAccount, On<BAccount.bAccountID, Equal<CROpportunity.bAccountID>>,
          LeftJoin<Contact, On<Contact.contactID, Equal<CROpportunity.contactID>>>>,
          Where<BAccount.bAccountID, IsNull, Or<Match<BAccount, Current<AccessInfo.userName>>>>,
          OrderBy<Desc<CROpportunity.opportunityID>>>),
          new[] { typeof(CROpportunity.opportunityID),
        typeof(CROpportunity.subject),
        typeof(CROpportunity.status),
        typeof(CROpportunity.curyAmount),
        typeof(CROpportunity.curyID),
        typeof(CROpportunity.closeDate),
        typeof(CROpportunity.stageID),
        typeof(CROpportunity.classID),
        typeof(CROpportunity.isActive),
        typeof(BAccount.acctName),
        typeof(Contact.displayName) },
            Filterable = true)]
        [PXFieldDescription]
        public virtual string OpportunityID { get; set; }
        public abstract class opportunityID : PX.Data.BQL.BqlString.Field<opportunityID> { }
        #endregion

        #region DocType
        [PXDBString(3, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Type", Visibility = PXUIVisibility.SelectorVisible, Enabled = true, TabOrder = 0)]
        [PXFieldDescription]
        public virtual string DocType { get; set; }
        public abstract class docType : PX.Data.BQL.BqlString.Field<docType> { }
        #endregion

        #region RefNbr
        [PXDBString(15, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Reference Nbr.", Visibility = PXUIVisibility.SelectorVisible, TabOrder = 1)]
        public virtual string RefNbr { get; set; }
        public abstract class refNbr : PX.Data.BQL.BqlString.Field<refNbr> { }
        #endregion

        #region DocDate
        [PXDBDate()]
        [PXUIField(DisplayName = "Doc Date")]
        public virtual DateTime? DocDate { get; set; }
        public abstract class docDate : PX.Data.BQL.BqlDateTime.Field<docDate> { }
        #endregion

        #region InvoiceAmt
        [PXDBDecimal()]
        [PXUIField(DisplayName = "Invoice Amt")]
        public virtual Decimal? InvoiceAmt { get; set; }
        public abstract class invoiceAmt : PX.Data.BQL.BqlDecimal.Field<invoiceAmt> { }
        #endregion
    }
}
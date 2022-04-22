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
    [PXCacheName("CKARRSummary")]
    public class CKARRSummary : IBqlTable
    {
        #region CampaignSourceID
        [PXDBString(10, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Campaign Source ID")]
        [PXSelector(typeof(CRCampaign.campaignID), DescriptionField = typeof(CRCampaign.campaignName))]
        [PXFieldDescription]
        public virtual string CampaignSourceID { get; set; }
        public abstract class campaignSourceID : PX.Data.BQL.BqlString.Field<campaignSourceID> { }
        #endregion

        #region AvgAmt
        [PXDBDecimal()]
        [PXUIField(DisplayName = "Avg Amt")]
        public virtual Decimal? AvgAmt { get; set; }
        public abstract class avgAmt : PX.Data.BQL.BqlDecimal.Field<avgAmt> { }
        #endregion

        #region Arramt
        [PXDBDecimal()]
        [PXUIField(DisplayName = "Arramt")]
        public virtual Decimal? Arramt { get; set; }
        public abstract class arramt : PX.Data.BQL.BqlDecimal.Field<arramt> { }
        #endregion
    }
}
using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PX.Objects.CR
{
    public class CROpportunityExt : PXCacheExtension<CROpportunity>
    {
        #region UsrOTYPE
        [PXString]
        [PXUIField(DisplayName = "專案屬性", Enabled = false)]
        public string UsrOTYPE { get; set; }
        public abstract class usrOTYPE : PX.Data.BQL.BqlString.Field<usrOTYPE> { }
        #endregion

        #region UsrPRODHIER
        [PXString]
        [PXUIField(DisplayName = "產品類別", Enabled = false)]
        public string UsrPRODHIER { get; set; }
        public abstract class usrPRODHIER : PX.Data.BQL.BqlString.Field<usrPRODHIER> { }
        #endregion

        #region UsrAWSSTATUS
        [PXString]
        [PXUIField(DisplayName = "AWS Status", Enabled = false)]
        public string UsrAWSSTATUS { get; set; }
        public abstract class usrAWSSTATUS : PX.Data.BQL.BqlString.Field<usrAWSSTATUS> { }
        #endregion

        #region UsrAWSAUTH
        [PXString]
        [PXUIField(DisplayName = "Authority (A)", Enabled = false)]
        public string UsrAWSAUTH { get; set; }
        public abstract class usrAWSAUTH : PX.Data.BQL.BqlString.Field<usrAWSAUTH> { }
        #endregion

        #region UsrAWSNEED
        [PXString]
        [PXUIField(DisplayName = "Needs (N)", Enabled = false)]
        public string UsrAWSNEED { get; set; }
        public abstract class usrAWSNEED : PX.Data.BQL.BqlString.Field<usrAWSNEED> { }
        #endregion

        #region UsrAWSFIT
        [PXString]
        [PXUIField(DisplayName = "Fitness (F)", Enabled = false)]
        public string UsrAWSFIT { get; set; }
        public abstract class usrAWSFIT : PX.Data.BQL.BqlString.Field<usrAWSFIT> { }
        #endregion

        #region UsrAWSCOMP
        [PXString]
        [PXUIField(DisplayName = "競爭對手", Enabled = false)]
        public string UsrAWSCOMP { get; set; }
        public abstract class usrAWSCOMP : PX.Data.BQL.BqlString.Field<usrAWSCOMP> { }
        #endregion

        #region UsrSOURCE
        [PXString]
        [PXUIField(DisplayName = "來源", Enabled = false)]
        public string UsrSOURCE { get; set; }
        public abstract class usrSOURCE : PX.Data.BQL.BqlString.Field<usrSOURCE> { }
        #endregion

        #region UsrBUDGET
        [PXString]
        [PXUIField(DisplayName = "專案預算", Enabled = false)]
        public string UsrBUDGET { get; set; }
        public abstract class usrBUDGET : PX.Data.BQL.BqlString.Field<usrBUDGET> { }
        #endregion

        #region UsrAPN
        [PXString]
        [PXUIField(DisplayName = "是否要上APN", Enabled = false)]
        public string UsrAPN { get; set; }
        public abstract class usrAPN : PX.Data.BQL.BqlString.Field<usrAPN> { }
        #endregion

        #region UsrBOOKDATE
        [PXDate]
        [PXUIField(DisplayName = "Booking Date", Enabled = false)]
        public DateTime? UsrBOOKDATE { get; set; }
        public abstract class usrBOOKDATE : PX.Data.BQL.BqlDateTime.Field<usrBOOKDATE> { }
        #endregion

        #region UsrUSECASE
        [PXString]
        [PXUIField(DisplayName = "Use Case", Enabled = false)]
        public string UsrUSECASE { get; set; }
        public abstract class usrUSECASE : PX.Data.BQL.BqlString.Field<usrUSECASE> { }
        #endregion

        #region UsrMAINREQ
        [PXString]
        [PXUIField(DisplayName = "主要需求", Enabled = false)]
        public string UsrMAINREQ { get; set; }
        public abstract class usrMAINREQ : PX.Data.BQL.BqlString.Field<usrMAINREQ> { }
        #endregion

        #region UsrPOCAMT
        [PXString]
        [PXUIField(DisplayName = "POC 申請金額", Enabled = false)]
        public string UsrPOCAMT { get; set; }
        public abstract class usrPOCAMT : PX.Data.BQL.BqlString.Field<usrPOCAMT> { }
        #endregion

        #region UsrAWSBD
        [PXString]
        [PXUIField(DisplayName = "AWS BD", Enabled = false)]
        public string UsrAWSBD { get; set; }
        public abstract class usrAWSBD : PX.Data.BQL.BqlString.Field<usrAWSBD> { }
        #endregion

        #region UsrAWSID
        [PXString]
        [PXUIField(DisplayName = "AWS ID", Enabled = false)]
        public string UsrAWSID { get; set; }
        public abstract class usrAWSID : PX.Data.BQL.BqlString.Field<usrAWSID> { }
        #endregion

        #region UsrDEALER
        [PXString]
        [PXUIField(DisplayName = "經銷商", Enabled = false)]
        public string UsrDEALER { get; set; }
        public abstract class usrDEALER : PX.Data.BQL.BqlString.Field<usrDEALER> { }
        #endregion

        #region UsrAPNID
        [PXString]
        [PXUIField(DisplayName = "APN ID", Enabled = false)]
        public string UsrAPNID { get; set; }
        public abstract class usrAPNID : PX.Data.BQL.BqlString.Field<usrAPNID> { }
        #endregion

        #region UsrCalculateCuryAmount
        [PXDecimal]
        [PXUIField(DisplayName = "原幣加權金額", Enabled = false)]
        public decimal? UsrCalculateCuryAmount { get; set; }
        public abstract class usrCalculateCuryAmount : PX.Data.BQL.BqlDecimal.Field<usrCalculateCuryAmount> { }
        #endregion

        #region UsrCalculateTWDAmount
        [PXDecimal]
        [PXUIField(DisplayName = "台幣加權金額", Enabled = false)]
        public decimal? UsrCalculateTWDAmount { get; set; }
        public abstract class usrCalculateTWDAmount : PX.Data.BQL.BqlDecimal.Field<usrCalculateTWDAmount> { }
        #endregion
    }
}

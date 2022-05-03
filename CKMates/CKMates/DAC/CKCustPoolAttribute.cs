using System;
using CKMates.Descripter;
using PX.Data;

namespace CKMates.DAC
{
    [Serializable]
    [PXCacheName("CKCustPoolAttribute")]
    public class CKCustPoolAttribute : IBqlTable
    {
        #region ContactID
        [PXDBInt()]
        [PXUIField(DisplayName = "Contact ID")]
        public virtual int? ContactID { get; set; }
        public abstract class contactID : PX.Data.BQL.BqlInt.Field<contactID> { }
        #endregion

        #region ContactType
        [PXDBString(2, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Contact Type")]
        public virtual string ContactType { get; set; }
        public abstract class contactType : PX.Data.BQL.BqlString.Field<contactType> { }
        #endregion

        #region UptoDate
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Upto Date")]
        public virtual string UptoDate { get; set; }
        public abstract class uptoDate : PX.Data.BQL.BqlString.Field<uptoDate> { }
        #endregion

        #region AttributeCLEVEL
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Attribute CLEVEL")]
        [PXString]
        [LUMCCLEVELDDLAttribute("CLEVEL")]
        public virtual string AttributeCLEVEL { get; set; }
        public abstract class attributeCLEVEL : PX.Data.BQL.BqlString.Field<attributeCLEVEL> { }
        #endregion

        #region AttributeSOURCE
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Attribute SOURCE")]
        [LUMCCLEVELDDLAttribute("SOURCE")]
        public virtual string AttributeSOURCE { get; set; }
        public abstract class attributeSOURCE : PX.Data.BQL.BqlString.Field<attributeSOURCE> { }
        #endregion

        #region Attributeindustry
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Attributeindustry")]
        [LUMCCLEVELDDLAttribute("INDUSTRY")]
        public virtual string Attributeindustry { get; set; }
        public abstract class attributeindustry : PX.Data.BQL.BqlString.Field<attributeindustry> { }
        #endregion

        #region AddressID
        [PXDBInt()]
        [PXUIField(DisplayName = "Address ID")]
        public virtual int? AddressID { get; set; }
        public abstract class addressID : PX.Data.BQL.BqlInt.Field<addressID> { }
        #endregion

        #region Status
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Status")]
        public virtual string Status { get; set; }
        public abstract class status : PX.Data.BQL.BqlString.Field<status> { }
        #endregion

        #region StageID
        [PXDBString(2, InputMask = "")]
        [PXUIField(DisplayName = "Stage ID")]
        public virtual string StageID { get; set; }
        public abstract class stageID : PX.Data.BQL.BqlString.Field<stageID> { }
        #endregion

        #region Probability
        [PXDBInt()]
        [PXUIField(DisplayName = "Probability")]
        public virtual int? Probability { get; set; }
        public abstract class probability : PX.Data.BQL.BqlInt.Field<probability> { }
        #endregion
    }
}

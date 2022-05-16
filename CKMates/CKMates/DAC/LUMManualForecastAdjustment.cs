using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using PX.TM;
using static PX.Data.PXAccess;

namespace CKMates.DAC
{
    [Serializable]
    [PXCacheName("LUMManualForecastAdjustment")]
    public class LUMManualForecastAdjustment : IBqlTable
    {
        #region WorkgroupID
        [PXDBInt(IsKey = true)]
        [PXDefault]
        [PXSelector(typeof(SelectFrom<EPCompanyTree>
                          .InnerJoin<EPCompanyTreeH>.On<EPCompanyTree.workGroupID.IsEqual<EPCompanyTreeH.workGroupID>>
                          .InnerJoin<LUMCompanyTreeMember>.On<EPCompanyTreeH.parentWGID.IsEqual<LUMCompanyTreeMember.workGroupID>>
                          .InnerJoin<BAccount2>.On<LUMCompanyTreeMember.contactID.IsEqual<BAccount2.defContactID>>
                          .InnerJoin<EPEmployee>.On<BAccount2.bAccountID.IsEqual<EPEmployee.bAccountID>>
                          .Where<EPEmployee.userID.IsEqual<AccessInfo.userID.FromCurrent>>
                          .SearchFor<EPCompanyTree.workGroupID>),
                        typeof(EPCompanyTree.description),
                        SubstituteKey = typeof(EPCompanyTree.description))]
        [PXUIField(DisplayName = "Workgroup ID", Enabled = false)]
        public virtual int? WorkgroupID { get; set; }
        public abstract class workgroupID : PX.Data.BQL.BqlInt.Field<workgroupID> { }
        #endregion

        #region Year
        [PXDBInt(IsKey = true)]
        [PXDefault]
        [PXUIField(DisplayName = "Year",Enabled = false)]
        public virtual int? Year { get; set; }
        public abstract class year : PX.Data.BQL.BqlInt.Field<year> { }
        #endregion

        #region Period01
        [PXDBInt()]
        [PXUIField(DisplayName = "Period01")]
        public virtual int? Period01 { get; set; }
        public abstract class period01 : PX.Data.BQL.BqlInt.Field<period01> { }
        #endregion

        #region Period02
        [PXDBInt()]
        [PXUIField(DisplayName = "Period02")]
        public virtual int? Period02 { get; set; }
        public abstract class period02 : PX.Data.BQL.BqlInt.Field<period02> { }
        #endregion

        #region Period03
        [PXDBInt()]
        [PXUIField(DisplayName = "Period03")]
        public virtual int? Period03 { get; set; }
        public abstract class period03 : PX.Data.BQL.BqlInt.Field<period03> { }
        #endregion

        #region Period04
        [PXDBInt()]
        [PXUIField(DisplayName = "Period04")]
        public virtual int? Period04 { get; set; }
        public abstract class period04 : PX.Data.BQL.BqlInt.Field<period04> { }
        #endregion

        #region Period05
        [PXDBInt()]
        [PXUIField(DisplayName = "Period05")]
        public virtual int? Period05 { get; set; }
        public abstract class period05 : PX.Data.BQL.BqlInt.Field<period05> { }
        #endregion

        #region Period06
        [PXDBInt()]
        [PXUIField(DisplayName = "Period06")]
        public virtual int? Period06 { get; set; }
        public abstract class period06 : PX.Data.BQL.BqlInt.Field<period06> { }
        #endregion

        #region Period07
        [PXDBInt()]
        [PXUIField(DisplayName = "Period07")]
        public virtual int? Period07 { get; set; }
        public abstract class period07 : PX.Data.BQL.BqlInt.Field<period07> { }
        #endregion

        #region Period08
        [PXDBInt()]
        [PXUIField(DisplayName = "Period08")]
        public virtual int? Period08 { get; set; }
        public abstract class period08 : PX.Data.BQL.BqlInt.Field<period08> { }
        #endregion

        #region Period09
        [PXDBInt()]
        [PXUIField(DisplayName = "Period09")]
        public virtual int? Period09 { get; set; }
        public abstract class period09 : PX.Data.BQL.BqlInt.Field<period09> { }
        #endregion

        #region Period10
        [PXDBInt()]
        [PXUIField(DisplayName = "Period10")]
        public virtual int? Period10 { get; set; }
        public abstract class period10 : PX.Data.BQL.BqlInt.Field<period10> { }
        #endregion

        #region Period11
        [PXDBInt()]
        [PXUIField(DisplayName = "Period11")]
        public virtual int? Period11 { get; set; }
        public abstract class period11 : PX.Data.BQL.BqlInt.Field<period11> { }
        #endregion

        #region Period12
        [PXDBInt()]
        [PXUIField(DisplayName = "Period12")]
        public virtual int? Period12 { get; set; }
        public abstract class period12 : PX.Data.BQL.BqlInt.Field<period12> { }
        #endregion


        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion
    }
}
using System;
using PX.Data;

namespace CKMates.DAC
{
    [Serializable]
    [PXCacheName("LUMManualForecastAdjustment")]
    public class LUMManualForecastAdjustment : IBqlTable
    {
        #region WorkgroupID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Workgroup ID")]
        public virtual int? WorkgroupID { get; set; }
        public abstract class workgroupID : PX.Data.BQL.BqlInt.Field<workgroupID> { }
        #endregion

        #region Year
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Year")]
        public virtual int? Year { get; set; }
        public abstract class year : PX.Data.BQL.BqlInt.Field<year> { }
        #endregion

        #region Period1
        [PXDBInt()]
        [PXUIField(DisplayName = "Period1")]
        public virtual int? Period1 { get; set; }
        public abstract class period1 : PX.Data.BQL.BqlInt.Field<period1> { }
        #endregion

        #region Period2
        [PXDBInt()]
        [PXUIField(DisplayName = "Period2")]
        public virtual int? Period2 { get; set; }
        public abstract class period2 : PX.Data.BQL.BqlInt.Field<period2> { }
        #endregion

        #region Period3
        [PXDBInt()]
        [PXUIField(DisplayName = "Period3")]
        public virtual int? Period3 { get; set; }
        public abstract class period3 : PX.Data.BQL.BqlInt.Field<period3> { }
        #endregion

        #region Period4
        [PXDBInt()]
        [PXUIField(DisplayName = "Period4")]
        public virtual int? Period4 { get; set; }
        public abstract class period4 : PX.Data.BQL.BqlInt.Field<period4> { }
        #endregion

        #region Period5
        [PXDBInt()]
        [PXUIField(DisplayName = "Period5")]
        public virtual int? Period5 { get; set; }
        public abstract class period5 : PX.Data.BQL.BqlInt.Field<period5> { }
        #endregion

        #region Period6
        [PXDBInt()]
        [PXUIField(DisplayName = "Period6")]
        public virtual int? Period6 { get; set; }
        public abstract class period6 : PX.Data.BQL.BqlInt.Field<period6> { }
        #endregion

        #region Period7
        [PXDBInt()]
        [PXUIField(DisplayName = "Period7")]
        public virtual int? Period7 { get; set; }
        public abstract class period7 : PX.Data.BQL.BqlInt.Field<period7> { }
        #endregion

        #region Period8
        [PXDBInt()]
        [PXUIField(DisplayName = "Period8")]
        public virtual int? Period8 { get; set; }
        public abstract class period8 : PX.Data.BQL.BqlInt.Field<period8> { }
        #endregion

        #region Period9
        [PXDBInt()]
        [PXUIField(DisplayName = "Period9")]
        public virtual int? Period9 { get; set; }
        public abstract class period9 : PX.Data.BQL.BqlInt.Field<period9> { }
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
using System;
using PX.Data;

namespace CKMates.DAC
{
    [Serializable]
    [PXCacheName("v_RollingForcastProcessResult")]
    public class v_RollingForcastProcessResult : IBqlTable
    {
        #region ForecastType
        [PXDBString(11, IsUnicode = true, InputMask = "", IsKey = true)]
        [PXUIField(DisplayName = "Forecast Type", Enabled = false)]
        public virtual string ForecastType { get; set; }
        public abstract class forecastType : PX.Data.BQL.BqlString.Field<forecastType> { }
        #endregion

        #region WorkGroupID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Work Group ID", Enabled = false)]
        public virtual int? WorkGroupID { get; set; }
        public abstract class workGroupID : PX.Data.BQL.BqlInt.Field<workGroupID> { }
        #endregion

        #region FinYear
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Fin Year", Enabled = false)]
        public virtual int? FinYear { get; set; }
        public abstract class finYear : PX.Data.BQL.BqlInt.Field<finYear> { }
        #endregion

        #region OrderSeq
        [PXDBInt()]
        [PXUIField(DisplayName = "Order Seq", Enabled = false)]
        public virtual int? OrderSeq { get; set; }
        public abstract class orderSeq : PX.Data.BQL.BqlInt.Field<orderSeq> { }
        #endregion

        #region Period01
        [PXDBDecimal()]
        [PXUIField(DisplayName = "1る", Enabled = false)]
        public virtual Decimal? Period01 { get; set; }
        public abstract class period01 : PX.Data.BQL.BqlDecimal.Field<period01> { }
        #endregion

        #region Period02
        [PXDBDecimal()]
        [PXUIField(DisplayName = "2る", Enabled = false)]
        public virtual Decimal? Period02 { get; set; }
        public abstract class period02 : PX.Data.BQL.BqlDecimal.Field<period02> { }
        #endregion

        #region Period03
        [PXDBDecimal()]
        [PXUIField(DisplayName = "3る", Enabled = false)]
        public virtual Decimal? Period03 { get; set; }
        public abstract class period03 : PX.Data.BQL.BqlDecimal.Field<period03> { }
        #endregion

        #region Period04
        [PXDBDecimal()]
        [PXUIField(DisplayName = "4る", Enabled = false)]
        public virtual Decimal? Period04 { get; set; }
        public abstract class period04 : PX.Data.BQL.BqlDecimal.Field<period04> { }
        #endregion

        #region Period05
        [PXDBDecimal()]
        [PXUIField(DisplayName = "5る", Enabled = false)]
        public virtual Decimal? Period05 { get; set; }
        public abstract class period05 : PX.Data.BQL.BqlDecimal.Field<period05> { }
        #endregion

        #region Period06
        [PXDBDecimal()]
        [PXUIField(DisplayName = "6る", Enabled = false)]
        public virtual Decimal? Period06 { get; set; }
        public abstract class period06 : PX.Data.BQL.BqlDecimal.Field<period06> { }
        #endregion

        #region Period07
        [PXDBDecimal()]
        [PXUIField(DisplayName = "7る", Enabled = false)]
        public virtual Decimal? Period07 { get; set; }
        public abstract class period07 : PX.Data.BQL.BqlDecimal.Field<period07> { }
        #endregion

        #region Period08
        [PXDBDecimal()]
        [PXUIField(DisplayName = "8る", Enabled = false)]
        public virtual Decimal? Period08 { get; set; }
        public abstract class period08 : PX.Data.BQL.BqlDecimal.Field<period08> { }
        #endregion

        #region Period09
        [PXDBDecimal()]
        [PXUIField(DisplayName = "9る", Enabled = false)]
        public virtual Decimal? Period09 { get; set; }
        public abstract class period09 : PX.Data.BQL.BqlDecimal.Field<period09> { }
        #endregion

        #region Period10
        [PXDBDecimal()]
        [PXUIField(DisplayName = "10る", Enabled = false)]
        public virtual Decimal? Period10 { get; set; }
        public abstract class period10 : PX.Data.BQL.BqlDecimal.Field<period10> { }
        #endregion

        #region Period11
        [PXDBDecimal()]
        [PXUIField(DisplayName = "11る", Enabled = false)]
        public virtual Decimal? Period11 { get; set; }
        public abstract class period11 : PX.Data.BQL.BqlDecimal.Field<period11> { }
        #endregion

        #region Period12
        [PXDBDecimal()]
        [PXUIField(DisplayName = "12る", Enabled = false)]
        public virtual Decimal? Period12 { get; set; }
        public abstract class period12 : PX.Data.BQL.BqlDecimal.Field<period12> { }
        #endregion

        #region DisplayPeriod01
        [PXString()]
        [PXUIField(DisplayName = "1る", Enabled = false)]
        public virtual String DisplayPeriod01 { get; set; }
        public abstract class displayPeriod01 : PX.Data.BQL.BqlString.Field<displayPeriod01> { }
        #endregion

        #region DisplayPeriod02
        [PXString()]
        [PXUIField(DisplayName = "2る", Enabled = false)]
        public virtual String DisplayPeriod02 { get; set; }
        public abstract class displayPeriod02 : PX.Data.BQL.BqlString.Field<displayPeriod02> { }
        #endregion

        #region DisplayPeriod03
        [PXString()]
        [PXUIField(DisplayName = "3る", Enabled = false)]
        public virtual String DisplayPeriod03 { get; set; }
        public abstract class displayPeriod03 : PX.Data.BQL.BqlString.Field<displayPeriod03> { }
        #endregion

        #region DisplayPeriod04
        [PXString()]
        [PXUIField(DisplayName = "4る", Enabled = false)]
        public virtual String DisplayPeriod04 { get; set; }
        public abstract class displayPeriod04 : PX.Data.BQL.BqlString.Field<displayPeriod04> { }
        #endregion

        #region DisplayPeriod05
        [PXString()]
        [PXUIField(DisplayName = "5る", Enabled = false)]
        public virtual String DisplayPeriod05 { get; set; }
        public abstract class displayPeriod05 : PX.Data.BQL.BqlString.Field<displayPeriod05> { }
        #endregion

        #region DisplayPeriod06
        [PXString()]
        [PXUIField(DisplayName = "6る", Enabled = false)]
        public virtual String DisplayPeriod06 { get; set; }
        public abstract class displayPeriod06 : PX.Data.BQL.BqlString.Field<displayPeriod06> { }
        #endregion

        #region DisplayPeriod07
        [PXString()]
        [PXUIField(DisplayName = "7る", Enabled = false)]
        public virtual String DisplayPeriod07 { get; set; }
        public abstract class displayPeriod07 : PX.Data.BQL.BqlString.Field<displayPeriod07> { }
        #endregion

        #region DisplayPeriod08
        [PXString()]
        [PXUIField(DisplayName = "8る", Enabled = false)]
        public virtual String DisplayPeriod08 { get; set; }
        public abstract class displayPeriod08 : PX.Data.BQL.BqlString.Field<displayPeriod08> { }
        #endregion

        #region DisplayPeriod09
        [PXString()]
        [PXUIField(DisplayName = "9る", Enabled = false)]
        public virtual String DisplayPeriod09 { get; set; }
        public abstract class displayPeriod09 : PX.Data.BQL.BqlString.Field<displayPeriod09> { }
        #endregion

        #region DisplayPeriod10
        [PXString()]
        [PXUIField(DisplayName = "10る", Enabled = false)]
        public virtual String DisplayPeriod10 { get; set; }
        public abstract class displayPeriod10 : PX.Data.BQL.BqlString.Field<displayPeriod10> { }
        #endregion

        #region DisplayPeriod11
        [PXString()]
        [PXUIField(DisplayName = "11る", Enabled = false)]
        public virtual String DisplayPeriod11 { get; set; }
        public abstract class displayPeriod11 : PX.Data.BQL.BqlString.Field<displayPeriod11> { }
        #endregion

        #region DisplayPeriod12
        [PXString()]
        [PXUIField(DisplayName = "12る", Enabled = false)]
        public virtual String DisplayPeriod12 { get; set; }
        public abstract class displayPeriod12 : PX.Data.BQL.BqlString.Field<displayPeriod11> { }
        #endregion

    }
}
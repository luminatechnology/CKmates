using System;
using PX.Data;

namespace CKMatesCRM.DAC
{
  [Serializable]
  [PXCacheName("CKLeadLaunch")]
  public class CKLeadLaunch : IBqlTable
  {
    #region Leadid
    [PXDBGuid()]
    [PXUIField(DisplayName = "Leadid")]
    public virtual Guid? Leadid { get; set; }
    public abstract class leadid : PX.Data.BQL.BqlGuid.Field<leadid> { }
    #endregion

    #region ContactID
    [PXDBInt()]
    [PXUIField(DisplayName = "Contact ID")]
    public virtual int? ContactID { get; set; }
    public abstract class contactID : PX.Data.BQL.BqlInt.Field<contactID> { }
    #endregion
  }
}
using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.TM;
using PX.Objects.EP;
using PX.Objects.CR;

namespace CKMatesCRM.DAC
{
    [Serializable]
    [PXCacheName("LUMCompanyTreeMember")]
    public class LUMCompanyTreeMember : IBqlTable
    {
        #region ContactID
        [PXDBInt()]
        [PXUIField(DisplayName = "Contact ID")]
        public virtual int? ContactID { get; set; }
        public abstract class contactID : PX.Data.BQL.BqlInt.Field<contactID> { }
        #endregion

        #region WorkGroupID
        [PXDBInt()]
        [PXUIField(DisplayName = "Work Group ID")]
        [PXSelector(typeof(SelectFrom<EPCompanyTree>
             //.InnerJoin<EPCompanyTreeMember>.On<EPCompanyTreeMember.workGroupID.IsEqual<EPCompanyTree.workGroupID>>
             //.InnerJoin<BAccount2>.On<EPCompanyTreeMember.contactID.IsEqual<BAccount2.defContactID>>
             //.InnerJoin<EPEmployee>.On<BAccount2.bAccountID.IsEqual<EPEmployee.bAccountID>>
             //.Where<EPEmployee.userID.IsEqual<AccessInfo.userID.FromCurrent>>
             .SearchFor<EPCompanyTree.workGroupID>),
              SubstituteKey = typeof(EPCompanyTree.description))]
        public virtual int? WorkGroupID { get; set; }
        public abstract class workGroupID : PX.Data.BQL.BqlInt.Field<workGroupID> { }
        #endregion

        #region Parentwgid
        [PXDBInt()]
        [PXUIField(DisplayName = "ParentWGID")]
        [PXSelector(typeof(SelectFrom<EPCompanyTree>
             //.InnerJoin<EPCompanyTreeMember>.On<EPCompanyTreeMember.workGroupID.IsEqual<EPCompanyTree.workGroupID>>
             //.InnerJoin<BAccount2>.On<EPCompanyTreeMember.contactID.IsEqual<BAccount2.defContactID>>
             //.InnerJoin<EPEmployee>.On<BAccount2.bAccountID.IsEqual<EPEmployee.bAccountID>>
             //.Where<EPEmployee.userID.IsEqual<AccessInfo.userID.FromCurrent>>
             .SearchFor<EPCompanyTree.workGroupID>),
              SubstituteKey = typeof(EPCompanyTree.description))]
        public virtual int? Parentwgid { get; set; }
        public abstract class parentwgid : PX.Data.BQL.BqlInt.Field<parentwgid> { }
        #endregion

        #region Rootwgid
        [PXDBInt()]
        [PXUIField(DisplayName = "RootWGID")]
        [PXSelector(typeof(SelectFrom<EPCompanyTree>
             //.InnerJoin<EPCompanyTreeMember>.On<EPCompanyTreeMember.workGroupID.IsEqual<EPCompanyTree.workGroupID>>
             //.InnerJoin<BAccount2>.On<EPCompanyTreeMember.contactID.IsEqual<BAccount2.defContactID>>
             //.InnerJoin<EPEmployee>.On<BAccount2.bAccountID.IsEqual<EPEmployee.bAccountID>>
             //.Where<EPEmployee.userID.IsEqual<AccessInfo.userID.FromCurrent>>
             .SearchFor<EPCompanyTree.workGroupID>),
              SubstituteKey = typeof(EPCompanyTree.description))]
        public virtual int? Rootwgid { get; set; }
        public abstract class rootwgid : PX.Data.BQL.BqlInt.Field<rootwgid> { }
        #endregion

        #region ChildLevel
        [PXDBInt()]
        [PXUIField(DisplayName = "Child Level")]
        public virtual int? ChildLevel { get; set; }
        public abstract class childLevel : PX.Data.BQL.BqlInt.Field<childLevel> { }
        #endregion
    }
}
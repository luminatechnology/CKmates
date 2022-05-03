using CKMates.DAC;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKMates.DAC_Inheritance
{
    public class CKMatesBAccount : BAccountR
    {
        [PXSelector(typeof(SelectFrom<BAccountR>
                           .InnerJoin<BAccountKvExt>.On<BAccountR.noteID.IsEqual<BAccountKvExt.recordID>>
                           .Where<BAccountKvExt.fieldName.IsEqual<CTYPEAttr>
                             .And<BAccountKvExt.valueString.IsEqual<CTYPEValueAttr>>>
                           .SearchFor<BAccountR.bAccountID>),
            typeof(BAccountR.acctCD),
            typeof(BAccountR.acctName),
            SubstituteKey = typeof(BAccountR.acctCD))]
        public override Int32? BAccountID { get; set; }
    }

    public class CTYPEAttr : PX.Data.BQL.BqlString.Constant<CTYPEAttr>
    {
        public CTYPEAttr() : base("AttributeCTYPE") { }
    }

    public class CTYPEValueAttr : PX.Data.BQL.BqlString.Constant<CTYPEValueAttr>
    {
        public CTYPEValueAttr() : base("02") { }
    }
}

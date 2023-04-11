using CKMates.Graph;
using PX.Data;
using PX.Objects.CR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKMates.Graph_Extension
{
    public class CRMassMailMaintExt : PXGraphExtension<CRMassMailMaint>
    {
        public PXAction<CRMassMail> Send;
        [PXUIField(DisplayName = PX.Objects.CR.Messages.Send)]
        [PXSendMailButton]
        public virtual IEnumerable send(PXAdapter a)
        {
            try
            {
                var unSubscribeGraph = PXGraph.CreateInstance<LUMUnsubscribeProcess>();
                unSubscribeGraph.UpdateUnsubscribeList(false);
            }
            catch (Exception)
            {
                throw new Exception("update Subscribe fail");
            }
            return Base.send(a);
        }
    }
}

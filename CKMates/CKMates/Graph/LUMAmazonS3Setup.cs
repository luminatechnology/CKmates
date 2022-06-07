using CKMates.DAC;
using PX.Data;
using PX.Data.BQL.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKMates.Graph
{
    public class LUMAmazonS3Setup : PXGraph<LUMAmazonS3Setup>
    {
        public PXSave<LUMAmazonS3Preference> Save;
        public PXCancel<LUMAmazonS3Preference> Cancel;
        public SelectFrom<LUMAmazonS3Preference>.View Preference;
    }
}

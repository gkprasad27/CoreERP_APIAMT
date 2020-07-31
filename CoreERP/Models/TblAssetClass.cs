using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetClass
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string NumberRange { get; set; }
        public string ClassType { get; set; }
        public string LowValueAssetClass { get; set; }
        public string AssetLowValue { get; set; }
    }
}

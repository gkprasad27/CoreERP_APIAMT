using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignAssetClasstoBlockAsset
    {
        public string Code { get; set; }
        public string AssetClass { get; set; }
        public string AssetBlock { get; set; }
        public string Description { get; set; }
    }
}

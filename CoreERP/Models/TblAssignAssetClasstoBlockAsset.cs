using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignAssetClasstoBlockAsset
    {
        public int Code { get; set; }
        public string AssetClass { get; set; }
        public string AssetBlock { get; set; }
    }
}

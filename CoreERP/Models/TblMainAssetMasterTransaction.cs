using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMainAssetMasterTransaction
    {
        public int Id { get; set; }
        public string AssetNumber { get; set; }
        public string DepreciationArea { get; set; }
        public string DepreciationCode { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? DepreciationStartDate { get; set; }
    }
}

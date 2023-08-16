using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSubAssetMasterTransaction
    {
        public int Id { get; set; }
        public string? SubAssetNumber { get; set; }
        public string? MainAssetNumber { get; set; }
        public string? DepreciationArea { get; set; }
        public string? DepreciationCode { get; set; }
        public decimal? DepreciationRate { get; set; }
        public DateTime? DepreciationStartDate { get; set; }
    }
}

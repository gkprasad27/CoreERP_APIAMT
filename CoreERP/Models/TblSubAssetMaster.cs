using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSubAssetMaster
    {
        public string SubAssetNumber { get; set; }
        public string MainAssetNo { get; set; }
        public string Description { get; set; }
        public string AccountKey { get; set; }
        public string MaterialNo { get; set; }
        public int? Quantity { get; set; }
        public string SerialNumber { get; set; }
        public string Branch { get; set; }
        public string ProfitCenter { get; set; }
        public string Segment { get; set; }
        public string Division { get; set; }
        public string Plant { get; set; }
        public string Location { get; set; }
        public string Room { get; set; }
        public string Supplier { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public int? UsefullLifeInDays { get; set; }
        public int? UsefulLifeInYears { get; set; }
        public string DepreciationData { get; set; }
        public string DepreciationArea { get; set; }
        public string DepreciationCode { get; set; }
        public DateTime? DepreciationStartDate { get; set; }
    }
}

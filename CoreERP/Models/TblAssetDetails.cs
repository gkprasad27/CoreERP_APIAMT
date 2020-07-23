using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetDetails
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string ProfitCenter { get; set; }
        public string Segment { get; set; }
        public string CostCenter { get; set; }
        public string MainAssetNo { get; set; }
        public string SubAssetNo { get; set; }
        public string DepreciationArea { get; set; }
        public string DepreciationCode { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public int? AcquisitionCost { get; set; }
        public string AccumulatedPreviousYearDepreciation { get; set; }
        public string AccumulatedDepreciationUptoDateCurrentYear { get; set; }
        public string Ext { get; set; }
    }
}

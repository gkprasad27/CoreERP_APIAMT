using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblDepreciationDetails
    {
        public int? Id { get; set; }
        public string? Company { get; set; }
        public string? Branch { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Segment { get; set; }
        public string? CostCenter { get; set; }
        public string? MainAssetNo { get; set; }
        public string? SubAssetNo { get; set; }
        public string? DepreciationArea { get; set; }
        public string? Month { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string? Year { get; set; }
        public string? DepreciationCode { get; set; }
        public string? DepreciationPostedUpto { get; set; }
        public DateTime? CurrentYearDate { get; set; }
        public DateTime? AccumulatedPreviousYearDeprecation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblDepreciation
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string DepreciationMethod { get; set; }
        public DateTime? PurchaseWithin { get; set; }
        public int? RatePercentage { get; set; }
        public decimal? MaxDepreciationAmount { get; set; }
        public DateTime? UptoDate { get; set; }
        public string DepreciationDuringLife { get; set; }
        public decimal? MaxDepreciationRate { get; set; }
        public int? Upto { get; set; }
        public int? NoofYears { get; set; }
        public int? NoofMonths { get; set; }
        public decimal? Rate { get; set; }
    }
}

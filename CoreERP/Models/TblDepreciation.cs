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
        public string RatePercentage { get; set; }
        public decimal? MaxDepreciation { get; set; }
        public DateTime? Upto { get; set; }
        public string DepreciationDuringLife { get; set; }
        public string Upto1 { get; set; }
        public string Upto2 { get; set; }
        public string Upto3 { get; set; }
        public string Upto4 { get; set; }
        public string Upto5 { get; set; }
        public string Upto6 { get; set; }
    }
}

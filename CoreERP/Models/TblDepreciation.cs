using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblDepreciation
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? DepreciationMethod { get; set; }
        public string? PurchaseWithin { get; set; }
        public int? Rate { get; set; }
        public decimal? MaxDepreciationAmount { get; set; }
        public decimal? MaxDepreciationRate { get; set; }
        public int? Upto1Years { get; set; }
        public int? Upto1Months { get; set; }
        public decimal? Upto1Rate { get; set; }
        public int? Upto2Years { get; set; }
        public int? Upto2Months { get; set; }
        public decimal? Upto2Rate { get; set; }
        public int? Upto3Years { get; set; }
        public int? Upto3Months { get; set; }
        public decimal? Upto3Rate { get; set; }
        public int? Upto4Years { get; set; }
        public int? Upto4Months { get; set; }
        public decimal? Upto4Rate { get; set; }
    }
}

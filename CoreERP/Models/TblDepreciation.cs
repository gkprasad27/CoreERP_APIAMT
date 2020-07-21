using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblDepreciation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DepreciationMethod { get; set; }
        public DateTime? PurchaseWithin { get; set; }
        public string RatePercentage { get; set; }
        public decimal? MaxDepreciation { get; set; }
        public DateTime? Upto { get; set; }
        public string DepreciationDuringLife { get; set; }
        public string Ext { get; set; }
    }
}

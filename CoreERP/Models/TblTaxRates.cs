using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTaxRates
    {
        public string? TaxRateCode { get; set; }
        public string? Description { get; set; }
        public string? TaxType { get; set; }
        public string? TaxTransaction { get; set; }
        public string? TaxCondition { get; set; }
        public decimal? Sgst { get; set; }
        public decimal? Cgst { get; set; }
        public decimal? Igst { get; set; }
        public decimal? Ugst { get; set; }
        public decimal? CompositeCess { get; set; }
        public DateTime? EffectiveFrom { get; set; }
    }
}

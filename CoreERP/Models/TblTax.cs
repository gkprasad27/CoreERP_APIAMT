using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTax
    {
        public decimal TaxId { get; set; }
        public string TaxName { get; set; }
        public string ApplicableOn { get; set; }
        public decimal? Rate { get; set; }
        public string CalculatingMode { get; set; }
        public string Narration { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTaxDetails
    {
        public decimal TaxdetailsId { get; set; }
        public decimal? TaxId { get; set; }
        public decimal? SelectedtaxId { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

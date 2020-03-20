using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSalesReturnBillTax
    {
        public decimal SalesReturnBillTaxId { get; set; }
        public decimal? SalesReturnMasterId { get; set; }
        public decimal? TaxId { get; set; }
        public decimal? TaxAmount { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

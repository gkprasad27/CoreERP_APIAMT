using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSupplierQuotationsMaster
    {
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? QuotationNumber { get; set; }
        public DateTime? SupplierQuoteDate { get; set; }
        public string? Supplier { get; set; }
        public int? DeliveryPeriod { get; set; }
        public int? CreditDays { get; set; }
        public string? DeliveryMethod { get; set; }
        public decimal? Advance { get; set; }
        public string? TransportMethod { get; set; }
        public string? Branch { get; set; }
        public string? ProfitCenter { get; set; }
        public DateTime? QuotationDate { get; set; }
        public string? Status { get; set; }
        public string? SupplierName { get; set; }
        public string? CompanyName { get; set; }
        public string? ProfitcenterName { get; set; }

    }
}

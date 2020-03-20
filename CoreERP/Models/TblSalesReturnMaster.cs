using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSalesReturnMaster
    {
        public decimal SalesReturnMasterId { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public decimal? SuffixPrefixId { get; set; }
        public decimal? SalesMasterId { get; set; }
        public decimal? LedgerId { get; set; }
        public decimal? SalesAccount { get; set; }
        public decimal? PricinglevelId { get; set; }
        public decimal? EmployeeId { get; set; }
        public string Narration { get; set; }
        public decimal? ExchangeRateId { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? UserId { get; set; }
        public string LrNo { get; set; }
        public string TransportationCompany { get; set; }
        public DateTime? Date { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? FinancialYearId { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

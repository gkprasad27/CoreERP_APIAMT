using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSalesOrderMaster
    {
        public decimal SalesOrderMasterId { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public decimal? SuffixPrefixId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Cancelled { get; set; }
        public decimal? LedgerId { get; set; }
        public decimal? PricinglevelId { get; set; }
        public decimal? EmployeeId { get; set; }
        public string Narration { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? UserId { get; set; }
        public decimal? QuotationMasterId { get; set; }
        public decimal? FinancialYearId { get; set; }
        public decimal? ExchangeRateId { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPartyBalance
    {
        public decimal PartyBalanceId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? LedgerId { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public string VoucherNo { get; set; }
        public decimal? AgainstVoucherTypeId { get; set; }
        public string AgainstVoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public string AgainstInvoiceNo { get; set; }
        public string ReferenceType { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public int? CreditPeriod { get; set; }
        public decimal? ExchangeRateId { get; set; }
        public decimal? FinancialYearId { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPdcpayableMaster
    {
        public decimal PdcPayableMasterId { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? SuffixPrefixId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? LedgerId { get; set; }
        public decimal? Amount { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string Narration { get; set; }
        public decimal? UserId { get; set; }
        public decimal? BankId { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public decimal? FinancialYearId { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

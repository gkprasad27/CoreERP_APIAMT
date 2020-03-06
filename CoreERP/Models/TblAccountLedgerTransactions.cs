using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAccountLedgerTransactions
    {
        public decimal LedgerTransactionId { get; set; }
        public decimal? LedgerId { get; set; }
        public string LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal? VoucherDetailId { get; set; }
        public decimal? VoucherAmount { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
    }
}

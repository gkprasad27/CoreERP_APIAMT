using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVoucherDetail
    {
        public decimal VoucherDetailId { get; set; }
        public decimal? VoucherMasterId { get; set; }
        public DateTime? VoucherDetailDate { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal? FromLedgerId { get; set; }
        public string FromLedgerCode { get; set; }
        public string FromLedgerName { get; set; }
        public decimal? ToLedgerId { get; set; }
        public string ToLedgerCode { get; set; }
        public string ToLedgerName { get; set; }
        public decimal? Amount { get; set; }
        public string TransactionType { get; set; }
        public string CostCenter { get; set; }
        public DateTime? ServerDate { get; set; }
        public string Narration { get; set; }
    }
}

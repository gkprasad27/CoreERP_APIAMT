using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBankReceiptMaster
    {
        public decimal BankReceiptMasterId { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BankReceiptVchNo { get; set; }
        public string VoucherNo { get; set; }
        public DateTime? BankReceiptDate { get; set; }
        public decimal? BankLedgerId { get; set; }
        public string BankLedgerName { get; set; }
        public string BankLedgerCode { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? PostingDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Realized { get; set; }
        public string Narration { get; set; }
        public decimal? UserId { get; set; }
        public string UserName { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? ShiftId { get; set; }
        public DateTime? ServerDate { get; set; }
    }
}

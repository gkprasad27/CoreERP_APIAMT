using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCashPaymentMaster
    {
        public decimal CashPaymentMasterId { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string CashPaymentVchNo { get; set; }
        public string VoucherNo { get; set; }
        public DateTime? CashPaymentDate { get; set; }
        public decimal? FromLedgerId { get; set; }
        public string FromLedgerName { get; set; }
        public string FromLedgerCode { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Narration { get; set; }
        public decimal? UserId { get; set; }
        public string UserName { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? ShiftId { get; set; }
        public DateTime? ServerDate { get; set; }

        public List<TblCashPaymentDetails> CashPaymentDetails { get; set; }
    }
}

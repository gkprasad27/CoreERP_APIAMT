using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOpeningBalance
    {
        public decimal OpeningBalanceId { get; set; }
        public decimal BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string VoucherNo { get; set; }
        public DateTime OpeningBalanceDate { get; set; }
        public decimal LedgerId { get; set; }
        public string LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public decimal PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public decimal Amount { get; set; }
        public string Narration { get; set; }
        public decimal ShiftId { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public decimal EmployeeId { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

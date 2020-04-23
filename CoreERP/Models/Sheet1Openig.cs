using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Sheet1Openig
    {
        public double? BranchId { get; set; }
        public double? BranchCode { get; set; }
        public string BranchName { get; set; }
        public double? VoucherNo { get; set; }
        public DateTime? OpeningBalanceDate { get; set; }
        public double? LedgerId { get; set; }
        public double? LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public double? PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public double? Credits { get; set; }
        public double? Debits { get; set; }
        public string Narration { get; set; }
        public double? ShiftId { get; set; }
        public double? UserId { get; set; }
        public string UserName { get; set; }
        public double? EmployeeId { get; set; }
    }
}

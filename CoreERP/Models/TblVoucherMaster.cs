using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVoucherMaster
    {
        public decimal VoucherMasterId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public DateTime? VoucherDate { get; set; }
        public decimal? VoucherTypeIdMain { get; set; }
        public decimal? VoucherTypeIdSub { get; set; }
        public string VoucherNo { get; set; }
        public decimal? Amount { get; set; }
        public string ChequeNo { get; set; }
        public string PaymentType { get; set; }
        public string Narration { get; set; }
        public DateTime? ServerDate { get; set; }
        public decimal? UserId { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? ShiftId { get; set; }
        public string UserName { get; set; }
    }
}

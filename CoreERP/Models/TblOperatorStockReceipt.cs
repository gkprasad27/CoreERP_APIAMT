using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOperatorStockReceipt
    {
        public decimal OperatorStockReceiptId { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string FromBranchCode { get; set; }
        public string FromBranchName { get; set; }
        public string ToBranchCode { get; set; }
        public string ToBranchName { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public decimal? ShiftId { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public decimal? EmployeeId { get; set; }
        public string Remarks { get; set; }
    }
}

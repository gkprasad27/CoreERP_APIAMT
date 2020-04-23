using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Sheet1
    {
        public double? BranchId { get; set; }
        public double? BranchCode { get; set; }
        public double? UserId { get; set; }
        public double? ShiftId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string VoucherTypeId { get; set; }
        public double? VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public double? ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double? InwardQty { get; set; }
        public double? Rate { get; set; }
        public string F14 { get; set; }
    }
}

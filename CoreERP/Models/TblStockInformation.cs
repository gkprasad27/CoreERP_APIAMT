using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockInformation
    {
        public decimal StockId { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public decimal? UserId { get; set; }
        public decimal? ShiftId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? ProductId { get; set; }
        public string ProductCode { get; set; }
        public decimal? InwardQty { get; set; }
        public decimal? OutwardQty { get; set; }
        public decimal? Rate { get; set; }
    }
}

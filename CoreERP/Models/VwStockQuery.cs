using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class VwStockQuery
    {
        public decimal? MasterId { get; set; }
        public string VoucherTypeName { get; set; }
        public string TypeOfVoucher { get; set; }
        public decimal VoucherTypeId { get; set; }
        public string VoucherNo { get; set; }
        public DateTime? Date { get; set; }
        public string ProductName { get; set; }
        public decimal? InwardQty { get; set; }
        public decimal? OutwardQty { get; set; }
        public decimal? Rate { get; set; }
        public string ProductCode { get; set; }
        public decimal? LedgerId { get; set; }
        public decimal? GroupId { get; set; }
        public decimal? AgainstVoucherTypeId { get; set; }
        public string AgainstInvoiceNo { get; set; }
        public string AgainstVoucherNo { get; set; }
    }
}

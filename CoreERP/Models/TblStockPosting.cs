using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockPosting
    {
        public decimal StockPostingId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? BatchId { get; set; }
        public decimal? UnitId { get; set; }
        public decimal? GodownId { get; set; }
        public decimal? RackId { get; set; }
        public decimal? AgainstVoucherTypeId { get; set; }
        public string AgainstInvoiceNo { get; set; }
        public string AgainstVoucherNo { get; set; }
        public decimal? InwardQty { get; set; }
        public decimal? OutwardQty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? FinancialYearId { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

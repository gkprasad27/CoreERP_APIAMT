using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockTransferDetail
    {
        public decimal? StockTransferDetailId { get; set; }
        public decimal? StockTransferMasterId { get; set; }
        public DateTime? StockTransferDetailsDate { get; set; }
        public decimal ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? HsnNo { get; set; }
        public decimal? Rate { get; set; }
        public decimal? ProductGroupId { get; set; }
        public decimal? ProductGroupCode { get; set; }
        public decimal? Qty { get; set; }
        public decimal? FQty { get; set; }
        public decimal? BatchNo { get; set; }
        public decimal? UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? AvailStock { get; set; }
        public decimal? Ltrs { get; set; }
    }
}

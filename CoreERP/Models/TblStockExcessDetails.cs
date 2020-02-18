using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockExcessDetails
    {
        public decimal StockExcessDetailId { get; set; }
        public decimal? StockExcessMasterId { get; set; }
        public DateTime? StockExcessDetailsDate { get; set; }
        public decimal ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal HsnNo { get; set; }
        public decimal? Rate { get; set; }
        public decimal Qty { get; set; }
        public decimal? BatchNo { get; set; }
        public decimal UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}

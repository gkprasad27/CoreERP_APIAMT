using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockEntryDetail
    {
        public decimal StockEntryDetailId { get; set; }
        public decimal StockEntryMasterId { get; set; }
        public string StockEntryNo { get; set; }
        public DateTime? StockEntryDate { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public decimal? ShiftId { get; set; }
        public decimal UserId { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal HsnNo { get; set; }
        public decimal? UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal? Qty { get; set; }
        public string BatchNo { get; set; }
        public decimal? StockValue { get; set; }
    }
}

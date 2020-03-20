using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPhysicalStockDetails
    {
        public decimal PhysicalStockDetailsId { get; set; }
        public decimal? PhysicalStockMasterId { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? UnitId { get; set; }
        public decimal? UnitConversionId { get; set; }
        public decimal? BatchId { get; set; }
        public decimal? GodownId { get; set; }
        public decimal? RackId { get; set; }
        public decimal? Amount { get; set; }
        public int? Slno { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

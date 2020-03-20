using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBom
    {
        public decimal BomId { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? RowmaterialId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitId { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public DateTime? ExtraDate { get; set; }
    }
}

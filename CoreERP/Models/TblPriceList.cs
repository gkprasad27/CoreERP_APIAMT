using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPriceList
    {
        public decimal PricelistId { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? PricinglevelId { get; set; }
        public decimal? UnitId { get; set; }
        public decimal? BatchId { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

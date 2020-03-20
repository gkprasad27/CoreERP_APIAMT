using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblUnitConvertion
    {
        public decimal UnitconversionId { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? UnitId { get; set; }
        public decimal? ConversionRate { get; set; }
        public string Quantities { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStandardRate
    {
        public decimal StandardRateId { get; set; }
        public DateTime? ApplicableFrom { get; set; }
        public DateTime? ApplicableTo { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? UnitId { get; set; }
        public decimal? BatchId { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

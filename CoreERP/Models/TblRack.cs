using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRack
    {
        public decimal RackId { get; set; }
        public string RackName { get; set; }
        public decimal? GodownId { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

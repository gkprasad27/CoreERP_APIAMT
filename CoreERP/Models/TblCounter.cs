using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCounter
    {
        public decimal CounterId { get; set; }
        public string CounterName { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

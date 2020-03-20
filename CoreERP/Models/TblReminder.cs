using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblReminder
    {
        public decimal ReminderId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string RemindAbout { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public DateTime? ExtraDate { get; set; }
    }
}

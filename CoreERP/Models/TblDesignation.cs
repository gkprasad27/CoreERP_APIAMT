using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblDesignation
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public decimal? LeaveDays { get; set; }
        public decimal? AdvanceAmount { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

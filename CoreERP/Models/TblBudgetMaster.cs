using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBudgetMaster
    {
        public decimal BudgetMasterId { get; set; }
        public string BudgetName { get; set; }
        public string Type { get; set; }
        public decimal? TotalDr { get; set; }
        public decimal? TotalCr { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Narration { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public DateTime? ExtraDate { get; set; }
    }
}

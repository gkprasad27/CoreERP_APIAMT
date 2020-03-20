using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBudgetDetails
    {
        public decimal BudgetDetailsId { get; set; }
        public decimal? BudgetMasterId { get; set; }
        public string Particular { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public DateTime? ExtraDate { get; set; }
    }
}

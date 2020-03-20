using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBonusDeduction
    {
        public decimal BonusDeductionId { get; set; }
        public decimal? EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Month { get; set; }
        public decimal? BonusAmount { get; set; }
        public decimal? DeductionAmount { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

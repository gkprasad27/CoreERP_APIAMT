using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblFinancialYear
    {
        public decimal FinancialYearId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

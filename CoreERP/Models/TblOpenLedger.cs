using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOpenLedger
    {
        public int Id { get; set; }
        public string? CompCode { get; set; }
        public string? LedgerKey { get; set; }
        public string? FinancialYearStartFrom { get; set; }
        public string? FinancialYearEndTo { get; set; }
        public string? AccountingYear { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

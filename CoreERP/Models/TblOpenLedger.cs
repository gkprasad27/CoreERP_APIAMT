using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOpenLedger
    {
        public int Id { get; set; }
        public string LedgerKey { get; set; }
        public DateTime? FinancialYearStartFrom { get; set; }
        public DateTime? FinancialYearEndTo { get; set; }
        public string AccountingYear { get; set; }
    }
}

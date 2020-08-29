using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOpenLedger
    {
        public int Id { get; set; }
        public string LedgerKey { get; set; }
        public string FinancialYearStartFrom { get; set; }
        public string FinancialYearEndTo { get; set; }
        public string AccountingYear { get; set; }
    }
}

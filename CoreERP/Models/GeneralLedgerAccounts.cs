using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class GeneralLedgerAccounts
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string AccountChart { get; set; }
        public string AccountGroup { get; set; }
        public string AccountLevel { get; set; }
        public string AccountNumber { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string ConsolidatedAccount { get; set; }
        public string Currency { get; set; }
        public string TaxCategory { get; set; }
        public string ControlAccount { get; set; }
        public bool? ClearingAccount { get; set; }
        public bool? NoPostingAllowed { get; set; }
        public bool? RelevantCashFlow { get; set; }
        public string BankKey { get; set; }
        public string LegacyGl { get; set; }
        public string CostElementCategory { get; set; }
        public string Ext { get; set; }
        public string Ext1 { get; set; }
    }
}

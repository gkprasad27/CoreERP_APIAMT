using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Glaccounts
    {
        public string ChartAccount { get; set; }
        public string AccGroup { get; set; }
        public string GlaccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Company { get; set; }
        public string ConsolidatedAccount { get; set; }
        public string Currency { get; set; }
        public string TaxCategory { get; set; }
        public string ControlAccount { get; set; }
        public string ClearingAccount { get; set; }
        public string NoPostingAllowed { get; set; }
        public string RelevantCashFlow { get; set; }
        public string BankKey { get; set; }
        public string LegacyGl { get; set; }
        public string CostElementCategory { get; set; }
        public string Subgroup { get; set; }
        public string GroupUnder { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Glaccounts
    {
        public string Glcode { get; set; }
        public string AccGroup { get; set; }
        public string GlaccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BalanceType { get; set; }
        public string OpeningBalance { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Nactureofaccount { get; set; }
        public string StatementType { get; set; }
        public string Active { get; set; }
    }
}

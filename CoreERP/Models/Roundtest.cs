using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Roundtest
    {
        public string Ledgercode { get; set; }
        public string BranchCode { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Roundoff { get; set; }
    }
}

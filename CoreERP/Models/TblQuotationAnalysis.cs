using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblQuotationAnalysis
    {
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Plant { get; set; }
        public string ProfitCenter { get; set; }
        public string Supplier { get; set; }
        public string QuotationNumber { get; set; }
    }
}

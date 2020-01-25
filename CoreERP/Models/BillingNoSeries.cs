using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class BillingNoSeries
    {
        public string Code { get; set; }
        public string BranchCode { get; set; }
        public string CompCode { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string NumberSeries { get; set; }
        public string Year { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

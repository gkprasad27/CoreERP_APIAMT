using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TaxIntegration
    {
        public string TaxCode { get; set; }
        public string BranchCode { get; set; }
        public string Cgst { get; set; }
        public string CompanyCode { get; set; }
        public string Description { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Igst { get; set; }
        public string Sgst { get; set; }
        public string Ugst { get; set; }
    }
}

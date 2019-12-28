using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TaxMasters
    {
        public string Code { get; set; }
        public decimal? BaseAmountInPerCentage { get; set; }
        public bool BaseAmountIncludingTax { get; set; }
        public decimal? Cgst { get; set; }
        public string Description { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public decimal? Igst { get; set; }
        public decimal? Sgst { get; set; }
        public string TaxType { get; set; }
        public decimal? Ugst { get; set; }
    }
}

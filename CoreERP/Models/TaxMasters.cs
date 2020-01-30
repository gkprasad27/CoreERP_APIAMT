using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TaxMasters
    {
        public string Code { get; set; }
        public decimal? BaseAmountInPerCentage { get; set; }
        public string BaseAmountIncludingTax { get; set; }
        public string Cgst { get; set; }
        public string Description { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Igst { get; set; }
        public string Sgst { get; set; }
        public string TaxType { get; set; }
        public string Ugst { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

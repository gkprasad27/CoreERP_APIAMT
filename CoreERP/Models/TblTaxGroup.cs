using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTaxGroup
    {
        public decimal TaxGroupId { get; set; }
        public string TaxGroupCode { get; set; }
        public string TaxGroupName { get; set; }
        public decimal? ProductGroupId { get; set; }
        public decimal? ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
        public string Narration { get; set; }
        public decimal? ProductLedgerId { get; set; }
        public string ProductLedgerName { get; set; }
    }
}

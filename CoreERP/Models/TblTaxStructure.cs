using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTaxStructure
    {
        public decimal TaxStructureId { get; set; }
        public decimal TaxStructureCode { get; set; }
        public decimal TaxGroupId { get; set; }
        public string TaxGroupCode { get; set; }
        public string TaxGroupName { get; set; }
        public string Description { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? PurchaseAccount { get; set; }
        public decimal? SalesAccount { get; set; }
        public decimal? TotalPercentageGst { get; set; }
        public decimal? Cgst { get; set; }
        public decimal? Sgst { get; set; }
        public decimal? Igst { get; set; }
        public decimal? TotalGst { get; set; }
        public string Narration { get; set; }
    }
}

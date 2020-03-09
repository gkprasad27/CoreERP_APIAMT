using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblProduct
    {
        public decimal ProductId { get; set; }
        public decimal? HsnNo { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductGroupId { get; set; }
        public decimal? ProductGroupCode { get; set; }
        public string ProductGroupName { get; set; }
        public decimal? PackingId { get; set; }
        public string PackingCode { get; set; }
        public string PackingName { get; set; }
        public decimal? PackingSize { get; set; }
        public decimal? TaxGroupId { get; set; }
        public string TaxGroupCode { get; set; }
        public string TaxGroupName { get; set; }
        public decimal? UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal? Mrp { get; set; }
        public decimal? PurchaseRate { get; set; }
        public decimal? SalesRate { get; set; }
        public decimal? TaxStructureId { get; set; }
        public decimal? TaxStructureCode { get; set; }
        public string TaxapplicableOn { get; set; }
        public decimal? TotalPercentageGst { get; set; }
        public decimal? Cgst { get; set; }
        public decimal? Sgst { get; set; }
        public decimal? Igst { get; set; }
        public decimal? TotalGst { get; set; }
        public decimal? SupplierId { get; set; }
        public decimal? SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string Narration { get; set; }
        public bool? IsActive { get; set; }
        public decimal? TaxapplicableOnId { get; set; }
    }
}

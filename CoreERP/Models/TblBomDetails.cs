using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBomDetails
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? BomKey { get; set; }
        public decimal? Rate { get; set; }
        public string? Component { get; set; }
        public string? Description { get; set; }
        public string? ManufacturingType { get; set; }
        public string? Type { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TaxAmount { get; set; }
        public int? Qty { get; set; }
        public string? TaxCode   { get; set; }
        public decimal? IGST { get; set; }
        public decimal? UGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? NetWeight { get; set; }
    }
}

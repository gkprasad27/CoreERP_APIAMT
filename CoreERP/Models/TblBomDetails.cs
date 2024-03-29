using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblBomDetails
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? BomKey { get; set; }
        public decimal? Rate { get; set; }
        public string? MaterialCode { get; set; }
        public string? MaterialName { get; set; }
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
       public DateTime? DeliveryDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public string? Addwho { get; set; }
        public string? Editwho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }
        public string? Billable { get; set; }
        public string? MainComponent { get; set; }
    }
}

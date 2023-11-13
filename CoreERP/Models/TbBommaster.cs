using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TbBommaster
    {
        public string? Company { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Bomtype { get; set; }
        public string? Bomnumber { get; set; }
        public string? ProfitCenter { get; set; }
        public decimal? TotalTax { get; set; }
        public string? Material { get; set; }
        public string? Batch { get; set; }
        public string? CreatedBy { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public decimal? IGST { get; set; }
        public decimal? UGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public string? CostCenter { get; set; }
        public string? SaleOrder { get; set; }
        public string? Product { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
        public string? ProfitcenterName { get; set; }
        public string? CompanyName { get; set; }
        public string? MaterialName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public string? Addwho { get; set; }
        public string? Editwho { get; set; }
    }
}

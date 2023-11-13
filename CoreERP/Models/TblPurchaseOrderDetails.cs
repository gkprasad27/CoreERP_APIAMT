using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblPurchaseOrderDetails
    {
        public int Id { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? MaterialCode { get; set; }
        public string? MaterialName { get; set; }
        public int? Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public string? TaxCode { get; set; }
        public decimal? IGST { get; set; }
        public decimal? UGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? Total { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? NetWeight { get; set; }
        public string? AddWho { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
    }
}

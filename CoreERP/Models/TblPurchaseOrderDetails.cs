using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseOrderDetails
    {
        public int Id { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public string? MaterialCode { get; set; }
        public int? Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? IGST { get; set; }
        public decimal? UGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? Total { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}

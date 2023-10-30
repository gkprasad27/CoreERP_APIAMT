using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseOrder
    {
        public string? CustPONumber { get; set; }
        public string? Company { get; set; }
        public string? SaleOrderNo { get; set; }
        public string? PurchaseOrderType { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? SupplierCode { get; set; }
        public string? Gstno { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }
        public decimal? Advance { get; set; }
        public string? TaxCode { get; set; }
        public decimal? IGST { get; set; }
        public decimal? UGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TotalTax { get; set; }
        public string? Location { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Status { get; set; }
        public string? saleOrderType { get; set; }

    }
}

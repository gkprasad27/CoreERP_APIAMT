using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblPurchaseOrder
    {

        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }
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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
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
        public string? CompanyName { get; set; }
        public string? ProfitcenterName { get; set; }
        public string? SupplierName { get; set; }
        public int TotalQty { get; set; }
        public string? Material { get; set; }
        public string? RecomendedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public string? DispatchMode { get; set; }
        public string? TermsOfDelivery { get; set; }
        public string? TermsOfPayment { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? ApprovalStatus { get; set; }
        public decimal? Fright { get; set; }
        public decimal? WeightBridge { get; set; }
        public decimal? OtherCharges { get; set; }
        public decimal? HamaliCharges { get; set; }
        public decimal? RoundOff { get; set; }

    }
}

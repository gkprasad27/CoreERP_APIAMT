using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseInvoiceDetail
    {
        public decimal PurchaseInvDetailId { get; set; }
        public decimal PurchaseInvId { get; set; }
        public string VoucherNo { get; set; }
        public string PurchaseNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string StateCode { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public decimal? ShiftId { get; set; }
        public decimal UserId { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal HsnNo { get; set; }
        public decimal? UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal? Qty { get; set; }
        public decimal? FQty { get; set; }
        public decimal? Barrel { get; set; }
        public string BatchNo { get; set; }
        public int? TankId { get; set; }
        public decimal? TankNo { get; set; }
        public decimal? TotalLiters { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? TaxGroupId { get; set; }
        public string TaxGroupCode { get; set; }
        public decimal? TaxStructureId { get; set; }
        public decimal? TaxStructureCode { get; set; }
        public decimal? Cgst { get; set; }
        public decimal? Sgst { get; set; }
        public decimal? Igst { get; set; }
        public decimal? TotalGst { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}

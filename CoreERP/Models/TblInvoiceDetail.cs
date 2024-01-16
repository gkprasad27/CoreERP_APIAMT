using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public string? InvoiceMasterId { get; set; }
        public string? VoucherNo { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? StateCode { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public string? ShiftId { get; set; }
        public string? UserId { get; set; }
        public string? EmployeeId { get; set; }
        public string? ProductId { get; set; }
        public string? HsnNo { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public decimal? Rate { get; set; }
        public string? ProductGroupId { get; set; }
        public string? ProductGroupCode { get; set; }
        public int? Qty { get; set; }
        public int? FQty { get; set; }
        public string? SlipNo { get; set; }
        public string? UnitId { get; set; }
        public string? UnitName { get; set; }
        public decimal? Discount { get; set; }
        public string? TaxGroupId { get; set; }
        public string? TaxGroupCode { get; set; }
        public string? TaxGroupName { get; set; }
        public string? TaxStructureId { get; set; }
        public string? TaxStructureCode { get; set; }
        public decimal? Cgst { get; set; }
        public decimal? Sgst { get; set; }
        public decimal? Igst { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? TotalGst { get; set; }
        public int? AvailStock { get; set; }
        public string? Saleorder { get; set; }
        public string? Status { get; set; }
        public string? MaterialCode { get; set; }
        public string? TagName { get; set; }
        public string? InspectionCheckNo { get; set; }
        public decimal? NetWeight { get; set; }
        public int? cgstcode { get; set; }
        public int? sgstcode { get; set; }
        public int? igstcode { get; set; }

    }
}

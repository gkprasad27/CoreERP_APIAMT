using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInvoiceDetail
    {
        public decimal InvoiceDetailId { get; set; }
        public decimal? InvoiceMasterId { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string StateCode { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public decimal? ShiftId { get; set; }
        public decimal UserId { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal ProductId { get; set; }
        public decimal HsnNo { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? Rate { get; set; }
        public decimal ProductGroupId { get; set; }
        public decimal ProductGroupCode { get; set; }
        public int PumpId { get; set; }
        public decimal PumpNo { get; set; }
        public decimal? Qty { get; set; }
        public decimal FQty { get; set; }
        public decimal SlipNo { get; set; }
        public decimal UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal? Discount { get; set; }
        public decimal TaxGroupId { get; set; }
        public string TaxGroupCode { get; set; }
        public string TaxGroupName { get; set; }
        public decimal TaxStructureId { get; set; }
        public decimal TaxStructureCode { get; set; }
        public decimal? Cgst { get; set; }
        public decimal? Sgst { get; set; }
        public decimal? Igst { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? TotalGst { get; set; }
        public decimal? AvailStock { get; set; }
    }
}

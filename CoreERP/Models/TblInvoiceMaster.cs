using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInvoiceMaster
    {
        public int InvoiceMasterId { get; set; }
        public string? VoucherNo { get; set; }
        public string? InvoiceNo { get; set; }
        public int? VoucherTypeId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? LedgerId { get; set; }
        public string? LedgerName { get; set; }
        public string? LedgerCode { get; set; }
        public string? Company { get; set; }
        public string? Profitcenter { get; set; }
        public int? PaymentMode { get; set; }
        public string? VehicleId { get; set; }
        public string? VehicleRegNo { get; set; }
        public decimal? MemberCode { get; set; }
        public string? MemberName { get; set; }
        public string? CustomerGstin { get; set; }
        public string? CustomerName { get; set; }
        public string? GeneralNo { get; set; }
        public string? StateCode { get; set; }
        public string? Mobile { get; set; }
        public string? SuppliedTo { get; set; }
        public decimal? AccountBalance { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public string? ShiftId { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? EmployeeId { get; set; }
        public decimal? Discount { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? TotalCgst { get; set; }
        public decimal? TotalSgst { get; set; }
        public decimal? TotalIgst { get; set; }
        public decimal? TotaltaxAmount { get; set; }
        public decimal? OtherAmount1 { get; set; }
        public decimal? OtherAmount2 { get; set; }
        public decimal? RoundOffPlus { get; set; }
        public decimal? RoundOffMinus { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? AmountInWords { get; set; }
        public bool? IsSalesReturned { get; set; }
        public bool? IsManualEntry { get; set; }
        public string? SaleOrderNo { get; set; }
        public int? InvoiceQty { get; set; }
        public string? Status { get; set; }
        public string? ShiptoAddress1 { get; set; }
        public string? ShiptoAddress2 { get; set; }
        public string? ShiptoState { get; set; }
        public string? ShiptoCity { get; set; }
        public string? ShiptoZip { get; set; }
        public string? ShiptoPhone { get; set; }
    }
}

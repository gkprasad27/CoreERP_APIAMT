using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInvoiceMaster
    {
        public decimal? InvoiceMasterId { get; set; }
        public string VoucherNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? LedgerId { get; set; }
        public string LedgerName { get; set; }
        public string LedgerCode { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal PaymentMode { get; set; }
        public decimal? VehicleId { get; set; }
        public string VehicleRegNo { get; set; }
        public decimal? MemberCode { get; set; }
        public string MemberName { get; set; }
        public string CustomerGstin { get; set; }
        public string CustomerName { get; set; }
        public string GeneralNo { get; set; }
        public string StateCode { get; set; }
        public string Mobile { get; set; }
        public string SuppliedTo { get; set; }
        public decimal? AccountBalance { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public decimal? ShiftId { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public decimal? EmployeeId { get; set; }
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
        public string AmountInWords { get; set; }
        public bool? IsSalesReturned { get; set; }
        public bool? IsManualEntry { get; set; }
        public string ManualInvoiceNo { get; set; }
    }
}

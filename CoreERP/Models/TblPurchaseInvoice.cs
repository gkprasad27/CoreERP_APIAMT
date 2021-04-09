using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseInvoice
    {
        public decimal? PurchaseInvId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string VoucherNo { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public string PurchaseInvNo { get; set; }
        public string SupplierInvNo { get; set; }
        public DateTime? PurchaseInvDate { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public decimal? LedgerId { get; set; }
        public string LedgerName { get; set; }
        public string LedgerCode { get; set; }
        public decimal? PaymentMode { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string Gstin { get; set; }
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
        public string Narration { get; set; }
        public bool? IsPurchaseReturned { get; set; }
        public decimal? TotalTcsAmount { get; set; }
    }
}

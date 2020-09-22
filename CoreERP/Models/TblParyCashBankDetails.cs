using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblParyCashBankDetails
    {
        public int Id { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime? VoucherDate { get; set; }
        public string PartyInvoiceNo { get; set; }
        public DateTime? PartyInvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? MemoAmount { get; set; }
        public decimal? ClearedAmount { get; set; }
        public decimal? BalanceDue { get; set; }
        public decimal? NotDue { get; set; }
        public decimal? AdjustmentAmount { get; set; }
        public decimal? Discount { get; set; }
        public string DiscountGl { get; set; }
        public string WriteOffAmount { get; set; }
        public string WriteOffGl { get; set; }
        public string Narration { get; set; }
        public string AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string EditWho { get; set; }
        public DateTime? EditDate { get; set; }
        public decimal? Writeoff { get; set; }
    }
}

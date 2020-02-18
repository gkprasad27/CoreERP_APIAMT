using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCashReceiptDetails
    {
        public decimal CashReceiptDetailsId { get; set; }
        public decimal? CashReceiptMasterId { get; set; }
        public DateTime? CashReceiptDetailsDate { get; set; }
        public decimal? ToLedgerId { get; set; }
        public string ToLedgerName { get; set; }
        public string ToLedgerCode { get; set; }
        public decimal? Amount { get; set; }
    }
}

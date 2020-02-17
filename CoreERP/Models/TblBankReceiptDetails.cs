using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBankReceiptDetails
    {
        public decimal BankReceiptDetailsId { get; set; }
        public decimal? BankReceiptMasterId { get; set; }
        public DateTime? BankReceiptDetailsDate { get; set; }
        public decimal? ToLedgerId { get; set; }
        public string ToLedgerName { get; set; }
        public string ToLedgerCode { get; set; }
        public decimal? Amount { get; set; }
    }
}

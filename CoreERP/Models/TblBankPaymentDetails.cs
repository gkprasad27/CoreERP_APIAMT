using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBankPaymentDetails
    {
        public decimal BankPaymentDetailsId { get; set; }
        public decimal? BankPaymentMasterId { get; set; }
        public DateTime? BankPaymentDetailsDate { get; set; }
        public decimal? ToLedgerId { get; set; }
        public string ToLedgerName { get; set; }
        public string ToLedgerCode { get; set; }
        public decimal? Amount { get; set; }
    }
}

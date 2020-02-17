using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCashPaymentDetails
    {
        public decimal CashPaymentDetailsId { get; set; }
        public decimal? CashPaymentMasterId { get; set; }
        public DateTime? CashPaymentDetailsDate { get; set; }
        public decimal? ToLedgerId { get; set; }
        public string ToLedgerName { get; set; }
        public string ToLedgerCode { get; set; }
        public decimal? Amount { get; set; }
    }
}

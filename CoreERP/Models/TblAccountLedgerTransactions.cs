using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAccountLedgerTransactions
    {
        public int Id { get; set; }
        public string LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string CostCenter { get; set; }
        public string Segment { get; set; }
        public DateTime? VoucherDate { get; set; }
        public string AccountingIndicator { get; set; }
        public string VoucherNumber { get; set; }
        public decimal? VoucherAmount { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public string AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string EditWho { get; set; }
        public DateTime? EditDate { get; set; }
        public string Status { get; set; }
    }
}

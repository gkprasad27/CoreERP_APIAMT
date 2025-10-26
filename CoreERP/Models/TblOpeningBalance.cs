using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOpeningBalance
    {
        public int? OpeningBalanceId { get; set; }
        public string CompanyCode { get; set; }
        public string VoucherNo { get; set; }
        public DateTime? OpeningBalanceDate { get; set; }
        public string LedgerId { get; set; }
        public string LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public string PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public decimal? Amount { get; set; }
        public string Narration { get; set; }
        public string AddWho { get; set; }
        public string EditWho { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}

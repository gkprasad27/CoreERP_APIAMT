using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAccountLedgerToCopy
    {
        public decimal LedgerId { get; set; }
        public decimal? AccountGroupId { get; set; }
        public string LedgerName { get; set; }
        public decimal? OpeningBalance { get; set; }
        public bool? IsDefault { get; set; }
        public string CrOrDr { get; set; }
        public string Narration { get; set; }
        public string MailingName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int? CreditPeriod { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? PricinglevelId { get; set; }
        public bool? BillByBill { get; set; }
        public string Tin { get; set; }
        public string Cst { get; set; }
        public string Pan { get; set; }
        public decimal? RouteId { get; set; }
        public string BankAccountNumber { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public decimal? AreaId { get; set; }
    }
}

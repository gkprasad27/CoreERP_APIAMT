using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBusinessPartnerAccount
    {
        public string? Company { get; set; }
        public string? Bptype { get; set; }
        public string? Bpgroup { get; set; }
        public string? Bpnumber { get; set; }
        public string? Name { get; set; }
        public string? Search { get; set; }
        public string? Address { get; set; }
        public string? Address1 { get; set; }
        public string? Location { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Gstno { get; set; }
        public string? Panno { get; set; }
        public string? Tanno { get; set; }
        public string? TaxClassification { get; set; }
        public string? ControlAccount { get; set; }
        public string? PaymentTerms { get; set; }
        public string? Tdstype { get; set; }
        public string? Tdsrate { get; set; }
        public int? BaseAmount { get; set; }
        public string? ObligationFrom { get; set; }
        public string? ObligationTo { get; set; }
        public string? BankKey { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? Ifsccode { get; set; }
        public string? Swiftcode { get; set; }
        public string? BankBranch { get; set; }
        public string? BankBranchNo { get; set; }
        public string? ContactPersion { get; set; }
        public string? ContactPersionMobile { get; set; }
        public string? Narration { get; set; }
        public string? Ext { get; set; }
        public string? ShiptoAddress1 { get; set; }
        public string? ShiptoAddress2 { get; set; }
        public string? ShiptoState { get; set; }
        public string? ShiptoCity { get; set; }
        public string? ShiptoZip { get; set; }
        public string? ShiptoPhone { get; set; }
        public decimal? ClosingBalance { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBankMaster
    {
        public int Id { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
        public string BranchNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public string Ifsccode { get; set; }
        public string Swiftkey { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Place { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string ContactPersion { get; set; }
        public string BankLimits { get; set; }
        public string Ext { get; set; }
    }
}

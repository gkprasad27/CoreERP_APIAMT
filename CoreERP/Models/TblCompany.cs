using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCompany
    {
        public decimal CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string MailingName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
        public string Web { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public decimal? CurrencyId { get; set; }
        public DateTime? FinancialYearFrom { get; set; }
        public DateTime? BooksBeginingFrom { get; set; }
        public string Gstin { get; set; }
        public string Cst { get; set; }
        public DateTime? CurrentDate { get; set; }
        public byte[] Logo { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string City { get; set; }
    }
}

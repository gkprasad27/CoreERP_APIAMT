using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCompany
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Street { get; set; }
        public decimal? Pin { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public string WebSite { get; set; }
        public string Panno { get; set; }
        public string Gstno { get; set; }
        public string Tanno { get; set; }
        public string Ext { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }

        public virtual Countries CountryNavigation { get; set; }
        public virtual TblCurrency CurrencyNavigation { get; set; }
        public virtual TblLanguage LanguageNavigation { get; set; }
        public virtual TblRegion RegionNavigation { get; set; }
        public virtual States StateNavigation { get; set; }
    }
}

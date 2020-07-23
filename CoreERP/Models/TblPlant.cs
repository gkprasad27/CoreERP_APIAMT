using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPlant
    {
        public int Id { get; set; }
        public string PlantCode { get; set; }
        public string Plantname { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Pin { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Panno { get; set; }
        public string Gstno { get; set; }
        public string Location { get; set; }
        public string Ext { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string ResponsiblePerson { get; set; }

        public virtual Countries CountryNavigation { get; set; }
        public virtual TblCurrency CurrencyNavigation { get; set; }
        public virtual TblLanguage LanguageNavigation { get; set; }
        public virtual TblRegion RegionNavigation { get; set; }
        public virtual States StateNavigation { get; set; }
    }
}

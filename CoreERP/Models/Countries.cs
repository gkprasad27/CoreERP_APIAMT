using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Countries
    {
        public Countries()
        {
            ProfitCenters = new HashSet<ProfitCenters>();
            SalesDepartment = new HashSet<SalesDepartment>();
            States = new HashSet<States>();
            TblBranch = new HashSet<TblBranch>();
            TblCompany = new HashSet<TblCompany>();
            TblPlant = new HashSet<TblPlant>();
            TblRegion = new HashSet<TblRegion>();
            TblSalesOffice = new HashSet<TblSalesOffice>();
        }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? Language { get; set; }
        public string? Currency { get; set; }
        public string? DecimalFormat { get; set; }
        public string? TimeFormat { get; set; }
        public string? DatFormat { get; set; }
        public string? AdditionlCurrencyKey { get; set; }
        public virtual TblCurrency CurrencyNavigation { get; set; }
        public virtual TblLanguage LanguageNavigation { get; set; }
        public virtual ICollection<ProfitCenters> ProfitCenters { get; set; }
        public virtual ICollection<SalesDepartment> SalesDepartment { get; set; }
        public virtual ICollection<States> States { get; set; }
        public virtual ICollection<TblBranch> TblBranch { get; set; }
        public virtual ICollection<TblCompany> TblCompany { get; set; }
        public virtual ICollection<TblPlant> TblPlant { get; set; }
        public virtual ICollection<TblRegion> TblRegion { get; set; }
        public virtual ICollection<TblSalesOffice> TblSalesOffice { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblLanguage
    {
        //public TblLanguage()
        //{
        //    Countries = new HashSet<Countries>();
        //    ProfitCenters = new HashSet<ProfitCenters>();
        //    States = new HashSet<States>();
        //    TblCompany = new HashSet<TblCompany>();
        //    TblPlant = new HashSet<TblPlant>();
        //    TblSalesOffice = new HashSet<TblSalesOffice>();
        //}
        public string? LanguageCode { get; set; }
        public string? LanguageName { get; set; }

        //public virtual ICollection<Countries> Countries { get; set; }
        //public virtual ICollection<ProfitCenters> ProfitCenters { get; set; }
        //public virtual ICollection<States> States { get; set; }
        //public virtual ICollection<TblCompany> TblCompany { get; set; }
        //public virtual ICollection<TblPlant> TblPlant { get; set; }
        //public virtual ICollection<TblSalesOffice> TblSalesOffice { get; set; }
    }
}

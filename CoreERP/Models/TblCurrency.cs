using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCurrency
    {
        //public TblCurrency()
        //{
        //    Countries = new HashSet<Countries>();
        //    ProfitCenters = new HashSet<ProfitCenters>();
        //    SalesDepartment = new HashSet<SalesDepartment>();
        //    TblBranch = new HashSet<TblBranch>();
        //    TblCompany = new HashSet<TblCompany>();
        //    TblPlant = new HashSet<TblPlant>();
        //    TblSalesOffice = new HashSet<TblSalesOffice>();
        //}
        public string CurrencySymbol { get; set; }
        public string CurrencyName { get; set; }
        public int? NoOfDecimalPlaces { get; set; }

        //public virtual ICollection<Countries> Countries { get; set; }
        //public virtual ICollection<ProfitCenters> ProfitCenters { get; set; }
        //public virtual ICollection<SalesDepartment> SalesDepartment { get; set; }
        //public virtual ICollection<TblBranch> TblBranch { get; set; }
        //public virtual ICollection<TblCompany> TblCompany { get; set; }
        //public virtual ICollection<TblPlant> TblPlant { get; set; }
        //public virtual ICollection<TblSalesOffice> TblSalesOffice { get; set; }
    }
}

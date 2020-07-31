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
            TblBranch = new HashSet<TblBranch>();
            TblCompany = new HashSet<TblCompany>();
            TblPlant = new HashSet<TblPlant>();
            TblSalesOffice = new HashSet<TblSalesOffice>();
        }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Language { get; set; }
        public string Currency { get; set; }
        public string Currency1 { get; set; }
        public string Currency2 { get; set; }
        public string DateFormat { get; set; }
        public string DecimalFormat { get; set; }
        public string TimeFormat { get; set; }

        public virtual ICollection<ProfitCenters> ProfitCenters { get; set; }
        public virtual ICollection<SalesDepartment> SalesDepartment { get; set; }
        public virtual ICollection<TblBranch> TblBranch { get; set; }
        public virtual ICollection<TblCompany> TblCompany { get; set; }
        public virtual ICollection<TblPlant> TblPlant { get; set; }
        public virtual ICollection<TblSalesOffice> TblSalesOffice { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRegion
    {
        //public TblRegion()
        //{
        //    ProfitCenters = new HashSet<ProfitCenters>();
        //    SalesDepartment = new HashSet<SalesDepartment>();
        //    TblBranch = new HashSet<TblBranch>();
        //    TblPlant = new HashSet<TblPlant>();
        //    TblSalesOffice = new HashSet<TblSalesOffice>();
        //}
        public string? RegionCode { get; set; }
        public string? RegionName { get; set; }
        public string? Country { get; set; }
        public string? Ext { get; set; }

        //public virtual Countries CountryNavigation { get; set; }
        //public virtual ICollection<ProfitCenters> ProfitCenters { get; set; }
        //public virtual ICollection<SalesDepartment> SalesDepartment { get; set; }
        //public virtual ICollection<TblBranch> TblBranch { get; set; }
        //public virtual ICollection<TblPlant> TblPlant { get; set; }
        //public virtual ICollection<TblSalesOffice> TblSalesOffice { get; set; }
    }
}

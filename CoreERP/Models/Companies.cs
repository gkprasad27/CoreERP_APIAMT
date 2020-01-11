using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Companies
    {
        public Companies()
        {
            Branches = new HashSet<Branches>();
            CostCenters = new HashSet<CostCenters>();
        }

        public string CompanyCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Email { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public int FinacialYear { get; set; }
        public int FromMonth { get; set; }
        public string Gstno { get; set; }
        public string Name { get; set; }
        public string NatureOfBusiness { get; set; }
        public string PanNo { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string PinCode { get; set; }
        public string Place { get; set; }
        public string State { get; set; }
        public string TanNo { get; set; }
        public int ToMonth { get; set; }
        public string Ext3 { get; set; }
        public string Ext4 { get; set; }
        public string Active { get; set; }

        public virtual ICollection<Branches> Branches { get; set; }
        public virtual ICollection<CostCenters> CostCenters { get; set; }
    }
}

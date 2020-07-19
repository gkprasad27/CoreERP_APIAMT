using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPayrollArea
    {
        public TblPayrollArea()
        {
            TblPayrollSubArea = new HashSet<TblPayrollSubArea>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Ext { get; set; }
        public string Ext1 { get; set; }

        public virtual ICollection<TblPayrollSubArea> TblPayrollSubArea { get; set; }
    }
}

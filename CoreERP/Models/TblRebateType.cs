using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRebateType
    {
        public TblRebateType()
        {
            TblRebateMaster = new HashSet<TblRebateMaster>();
        }

        public decimal RebateId { get; set; }
        public string RebateName { get; set; }

        public virtual ICollection<TblRebateMaster> TblRebateMaster { get; set; }
    }
}

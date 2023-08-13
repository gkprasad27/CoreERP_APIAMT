using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblWorkcenterActivity
    {
        public string? WorkcenterCode { get; set; }
        public string? Activity { get; set; }
        public string? Description { get; set; }
        public int? Uom { get; set; }
        public string? CostCenter { get; set; }
        public string? Formula { get; set; }
    }
}

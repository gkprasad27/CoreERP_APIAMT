using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCostingActivity
    {
        public string ActivityCode { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public string BasisofFixedPrice { get; set; }
        public string CostElement { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPrimaryCostElement
    {
        public string? Company { get; set; }
        public string? ChartofAccount { get; set; }
        public string? GeneralLedger { get; set; }
        public string? Description { get; set; }
        public string? Usage { get; set; }
        public string? Element { get; set; }
        public decimal? Qty { get; set; }
        public int? Uom { get; set; }
    }
}

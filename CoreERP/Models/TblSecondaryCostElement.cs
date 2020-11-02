using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSecondaryCostElement
    {
        public string Company { get; set; }
        public string ChartofAccount { get; set; }
        public string SecondaryCostCode { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string RecordQty { get; set; }
        public int? Uom { get; set; }
    }
}

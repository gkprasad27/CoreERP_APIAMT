using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCostingNumberSeries
    {
        public string NumberObject { get; set; }
        public int? FromInterval { get; set; }
        public int? ToInterval { get; set; }
        public string NonNumaric { get; set; }
        public string Prefix { get; set; }
        public int? PresentNumber { get; set; }
    }
}

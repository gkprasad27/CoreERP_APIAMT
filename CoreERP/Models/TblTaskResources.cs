using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTaskResources
    {
        public string? TaskNumber { get; set; }
        public string? Resource { get; set; }
        public string? MaterialCode { get; set; }
        public int? Qty { get; set; }
        public string? CostCenter { get; set; }
        public string? Activity { get; set; }
        public decimal? Rate { get; set; }
    }
}

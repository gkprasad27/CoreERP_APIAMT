using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOrderType
    {
        public string? OrderType { get; set; }
        public string? Description { get; set; }
        public string? PrintText { get; set; }
        public string? NatureofOrder { get; set; }
        public int? NumberSeriesFrom { get; set; }
        public int? NumberSeriesTo { get; set; }
        public string? CostUnit { get; set; }
    }
}

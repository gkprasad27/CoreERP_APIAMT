using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseOrderNoRange
    {
        public string? numberRange { get; set; }
        public int? FromInterval { get; set; }
        public int? ToInterval { get; set; }
        public int? CurrentNumber { get; set; }
        public string? Prefix { get; set; }
        public string? Plant { get; set; }
        public string? Department { get; set; }
    }
}

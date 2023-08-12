using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblNumberRange
    {
        public string? Code { get; set; }
        public int? RangeFrom { get; set; }
        public int? RangeTo { get; set; }
        public string? Description { get; set; }
        public string? NonNumaric { get; set; }
    }
}

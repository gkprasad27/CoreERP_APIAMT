using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMrnnoSeries
    {
        public string? Mrnseries { get; set; }
        public string? Description { get; set; }
        public int? FromInterval { get; set; }
        public int? ToInterval { get; set; }
        public int? CurrentNumber { get; set; }
        public string? Prefix { get; set; }
    }
}

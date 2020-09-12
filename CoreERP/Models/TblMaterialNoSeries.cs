using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialNoSeries
    {
        public string Code { get; set; }
        public int? FromInterval { get; set; }
        public int? ToInterval { get; set; }
        public int? CurrentNumber { get; set; }
        public string NonNumaric { get; set; }
        public string Prefix { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPrnoRange
    {
        public string Plant { get; set; }
        public string Department { get; set; }
        public string Code { get; set; }
        public int? FromInterval { get; set; }
        public int? ToInterval { get; set; }
        public int? CurrentNumber { get; set; }
        public string Prefix { get; set; }
    }
}

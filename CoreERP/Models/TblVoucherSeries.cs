using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVoucherSeries
    {
        public string VoucherSeriesKey { get; set; }
        public string FromInterval { get; set; }
        public string ToInterval { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Plant { get; set; }
        public string Suffix { get; set; }
        public string Year { get; set; }
        public string Prefix { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPosting
    {
        public int Code { get; set; }
        public string Tdsrate { get; set; }
        public string Glaccount { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Plant { get; set; }
        public string ChartofAccount { get; set; }
    }
}

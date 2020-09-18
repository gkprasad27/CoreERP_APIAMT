using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblFundCenter
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Person { get; set; }
        public string Department { get; set; }
        public string CostCenter { get; set; }
        public string ProfitCenter { get; set; }
        public string Segment { get; set; }
    }
}

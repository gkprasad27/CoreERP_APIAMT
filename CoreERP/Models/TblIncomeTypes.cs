using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblIncomeTypes
    {
        public string? Code { get; set; }
        public string? Desctiption { get; set; }
        public string? SectionCode { get; set; }
        public decimal? ThresholdLimit { get; set; }
        public decimal? ThresholdContract { get; set; }
        public string? Ext { get; set; }
    }
}

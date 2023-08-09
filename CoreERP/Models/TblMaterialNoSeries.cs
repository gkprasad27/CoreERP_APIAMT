using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialNoSeries
    {
        public string? Code { get; set; }
        public int? FromInterval { get; set; }
        public int? ToInterval { get; set; }
        public int? CurrentNumber { get; set; }
        public string? NonNumeric { get; set; }
        public string? Prefix { get; set; }
        public string? Autogenerator { get; set; }
        public string? Ext { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Ptmaster
    {
        public string Ptslab { get; set; }
        public string? Year { get; set; }
        public string? Month { get; set; }
        public string? Location { get; set; }
        public double? PtlowerLimit { get; set; }
        public double? PtupperLimit { get; set; }
        public double? Ptamt { get; set; }
        public string? Active { get; set; }
        public string? Ext1 { get; set; }
    }
}

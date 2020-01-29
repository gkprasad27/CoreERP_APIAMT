using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Ptmaster
    {
        public int Id { get; set; }
        public string PtSlab { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Location { get; set; }
        public double? PtLowerLimit { get; set; }
        public double? PtUpperLimit { get; set; }
        public double? PtAmt { get; set; }
        public string Usrid { get; set; }
        public string Formno { get; set; }
        public string Trmno { get; set; }
        public string Active { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblProcess
    {
        public string Company { get; set; }
        public string Plant { get; set; }
        public string CostUnit { get; set; }
        public string Material { get; set; }
        public string ProcessKey { get; set; }
        public string NextProcess { get; set; }
        public string Wipcalculation { get; set; }
        public string ByProduct { get; set; }
        public string JointProduct { get; set; }
        public string ReWork { get; set; }
        public int? NormalLossIn { get; set; }
        public int? AbnormalLossIn { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMasterCopy
    {
        public int MasterId { get; set; }
        public int? FormName { get; set; }
        public bool? IsTwoLineForHedder { get; set; }
        public bool? IsTwoLineForDetails { get; set; }
        public int? PageSize1 { get; set; }
        public int? PageSizeOther { get; set; }
        public int? BlankLneForFooter { get; set; }
        public string FooterLocation { get; set; }
        public int? LineCountBetweenTwo { get; set; }
        public string Pitch { get; set; }
        public string Condensed { get; set; }
        public int? LineCountAfterPrint { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialGroups
    {
        public string? GroupKey { get; set; }
        public string? Description { get; set; }
        public string? narration { get; set; }
        public string? extra1 { get; set; }
        public string? extra2 { get; set; }
        public DateTime? extraDate { get; set; }
    }
}

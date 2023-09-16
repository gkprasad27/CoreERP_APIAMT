using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAccountGroup
    {
        public string? StructureKey { get; set; }
        public string? Nature { get; set; }
        public string? GroupUnder { get; set; }
        public string? Undersubaccount { get; set; }
        public string? AccountGroupId { get; set; }
        public string? AccountGroupName { get; set; }
        public string? Narration { get; set; }
        public int? IsDefault { get; set; }
        public string? Note { get; set; }
        public string? StructureType { get; set; }

    }
}

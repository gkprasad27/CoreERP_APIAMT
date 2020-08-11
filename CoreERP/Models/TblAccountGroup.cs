using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAccountGroup
    {
        public string AccountGroupId { get; set; }
        public string AccountGroupName { get; set; }
        public string GroupUnder { get; set; }
        public string Narration { get; set; }
        public bool? IsDefault { get; set; }
        public string Nature { get; set; }
        public int? Hirarchy { get; set; }
    }
}

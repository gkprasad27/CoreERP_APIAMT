using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class GlaccSubGroup
    {
        public string SubGroupCode { get; set; }
        public string AccGroup { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string SubGroupName { get; set; }
        public string UnderSubGroupCode { get; set; }
    }
}

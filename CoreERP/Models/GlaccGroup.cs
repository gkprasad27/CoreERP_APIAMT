using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class GlaccGroup
    {
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string NumberRange { get; set; }
        public string Active { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
    }
}

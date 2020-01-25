using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class GlaccUnderSubGroup
    {
        public string UnderSubGroupCode { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string GroupName { get; set; }
        public string SubGroupName { get; set; }
        public string UnderSubGroupName { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

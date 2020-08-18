using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class GlaccGroup
    {
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string NumberRangeFrom { get; set; }
        public string NumberRangeTo { get; set; }
        public string GroupType { get; set; }
        public string Active { get; set; }
        public int? Sequence { get; set; }
    }
}

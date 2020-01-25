using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class GlsubCode
    {
        public string SubCode { get; set; }
        public string Description { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Glcode { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

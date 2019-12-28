using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Counters
    {
        public int Code { get; set; }
        public string BranchCode { get; set; }
        public string CompCode { get; set; }
        public string Description { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Ext3 { get; set; }
        public string Ext4 { get; set; }
        public int? NumberRange { get; set; }
        public string Prefix { get; set; }
    }
}

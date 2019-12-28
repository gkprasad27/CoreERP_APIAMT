using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class MenuAccesses
    {
        public int MenuId { get; set; }
        public string CompCode { get; set; }
        public string BranchCode { get; set; }
        public string RoleId { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Ext3 { get; set; }
        public string Ext4 { get; set; }
        public int? Access { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class ApprovalType
    {
        public int ApprovalId { get; set; }
        public string ApprovalScreen { get; set; }
        public string RecommendedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string CompanyCode { get; set; }
        public string BranchCode { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Ext3 { get; set; }
        public string Ext4 { get; set; }
    }
}

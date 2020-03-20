using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblUserProductBranch
    {
        public decimal UserProductBranchId { get; set; }
        public decimal BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
    }
}

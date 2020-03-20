using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblUserBranch
    {
        public decimal Id { get; set; }
        public decimal? UserId { get; set; }
        public string BranchName { get; set; }
    }
}

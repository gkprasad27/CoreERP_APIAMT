using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class EmployeeInBranches
    {
        public string BranchCode { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

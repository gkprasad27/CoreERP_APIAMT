using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class LeaveTypes
    {
        public string LeaveCode { get; set; }
        public string CompanyCode { get; set; }
        public string Remarks { get; set; }
        public int? LeaveMinLimit { get; set; }
        public int? LeaveMaxLimit { get; set; }
        public string LeaveName { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
        public string BranchCode { get; set; }
        public string Ext1 { get; set; }
    }
}

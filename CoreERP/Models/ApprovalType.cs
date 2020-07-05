using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class ApprovalType
    {
        public int? Id { get; set; }
        public string ApprovalType1 { get; set; }
        public string ImmediateReporting { get; set; }
        public string ReportingTo { get; set; }
        public string ApprovedBy { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string ApproveName { get; set; }
    }
}

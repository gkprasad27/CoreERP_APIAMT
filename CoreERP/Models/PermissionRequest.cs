using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class PermissionRequest
    {
        public int Id { get; set; }
        public string? EmpCode { get; set; }
        public DateTime? PermissionDate { get; set; }
        public string? Status { get; set; }
        public string? CompanyCode { get; set; }
        public string? FromTime { get; set; }
        public string? ToTime { get; set; }
        public string? Reason { get; set; }
        public string? ApprovedId { get; set; }
        public string? ApprovedName { get; set; }
        public string? EmpName { get; set; }
        public string? ReportId { get; set; }
        public string? ReportName { get; set; }
        public string? RecommendedBy { get; set; }
        public string? RejectedId { get; set; }
        public string? RejectedName { get; set; }
        public string? RejectReason { get; set; }
        public string? Purpose { get; set; }
        public string? Department { get; set; }
        public DateTime? Fromdate { get; set; }
        public DateTime? Todate { get; set; }
    }
}

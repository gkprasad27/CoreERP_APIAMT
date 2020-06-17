using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class LeaveApplDetails
    {
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public int Sno { get; set; }
        public DateTime? ApplDate { get; set; }
        public string LeaveCode { get; set; }
        public DateTime? LeaveFrom { get; set; }
        public DateTime? LeaveTo { get; set; }
        public double? LeaveDays { get; set; }
        public string LeaveRemarks { get; set; }
        public string Status { get; set; }
        public string ApprovedId { get; set; }
        public string ApproveName { get; set; }
        public string Reason { get; set; }
        public string AuthorizedStatus { get; set; }
        public string AuthorizedId { get; set; }
        public string Formno { get; set; }
        public string Trmno { get; set; }
        public DateTime? ApprDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AccptedId { get; set; }
        public DateTime? AccDate { get; set; }
        public string AcceptedRemarks { get; set; }
        public string Skip { get; set; }
        public int? Lopdays { get; set; }
        public string ReportId { get; set; }
        public string ReportName { get; set; }
        public string Recomendedby { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string RejectedId { get; set; }
        public string RejectedName { get; set; }
        public double? CountofLeaves { get; set; }
        public string ChkAcceptReject { get; set; }
        public string Session1 { get; set; }
        public string Session2 { get; set; }
    }
}

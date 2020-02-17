using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class MissingPunch
    {
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public int Sno { get; set; }
        public DateTime? ApplDate { get; set; }
        public string Status { get; set; }
        public string ApprovedId { get; set; }
        public string ApproveName { get; set; }
        public string Reason { get; set; }
        public string AuthorizedStatus { get; set; }
        public string AuthorizedId { get; set; }
        public DateTime? ApprDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AccptedId { get; set; }
        public DateTime? AccDate { get; set; }
        public string AcceptedRemarks { get; set; }
        public string ReportId { get; set; }
        public string ReportName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string RejectedId { get; set; }
        public string RejectedName { get; set; }
        public string CompanyGroupCode { get; set; }
        public string CompanyGroupName { get; set; }
        public DateTime? MissingDate { get; set; }
        public int? Id { get; set; }
    }
}

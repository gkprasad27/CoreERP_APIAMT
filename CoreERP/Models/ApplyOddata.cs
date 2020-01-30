using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class ApplyOddata
    {
        public int Sno { get; set; }
        public string EmpCode { get; set; }
        public DateTime? ApplDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Remarks { get; set; }
        public string RecBy { get; set; }
        public string RecStatus { get; set; }
        public DateTime? RecDate { get; set; }
        public string ApprBy { get; set; }
        public string ApprStatus { get; set; }
        public DateTime? ApprDate { get; set; }
        public string Reason { get; set; }
        public string AcceptedBy { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Skip { get; set; }
        public string Transport { get; set; }
        public string VisitingPlace { get; set; }
        public string EmpName { get; set; }
        public string VisitingPlacePurpus { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string ApprovedId { get; set; }
        public string ApproveName { get; set; }
        public string ReportId { get; set; }
        public string ReportName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double? NoOfDays { get; set; }
        public string RejectedId { get; set; }
        public string RejectedName { get; set; }
        public string Department { get; set; }
        public string CompanyGroupCode { get; set; }
        public string CompanyGroupName { get; set; }
        public string Active { get; set; }
    }
}

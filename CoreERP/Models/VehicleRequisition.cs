using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class VehicleRequisition
    {
        public int Sno { get; set; }
        public string EmpCode { get; set; }
        public DateTime ApplDate { get; set; }
        public DateTime? FromDate { get; set; }
        public string FromTime { get; set; }
        public DateTime? Todate { get; set; }
        public string Totime { get; set; }
        public string Place { get; set; }
        public string Purpose { get; set; }
        public string ApprovedId { get; set; }
        public string ReportId { get; set; }
        public string UserId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string ReportingTime { get; set; }
        public string ReprtingAddress { get; set; }
        public DateTime? ApprDate { get; set; }
        public DateTime? RecDate { get; set; }
        public DateTime? AccDate { get; set; }
        public string ContactPersonNo { get; set; }
        public string Skip { get; set; }
        public string Reason { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public bool? Recommendedby { get; set; }
        public string Status { get; set; }
        public string ApproveName { get; set; }
        public string ReportName { get; set; }
        public string AccptedId { get; set; }
        public string Approvedby { get; set; }
        public string Company { get; set; }
        public string RejectedName { get; set; }
        public string RejectedId { get; set; }
        public string CompanyGroupCode { get; set; }
        public string CompanyGroupName { get; set; }
    }
}

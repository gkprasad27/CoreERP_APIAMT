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
        //public double? CountofLeaves { get; set; }
       public string LeaveRemarks { get; set; }
        public string Status { get; set; }
        public string ApprovedId { get; set; }
        public string ApprovedName { get; set; }
        public string Reason { get; set; }
        //public string chkAcceptReject { get; set; }
        public string RecommendedId { get; set; }
        public string RecommendedName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string AcceptedRemarks { get; set; }
        public string CompanyCode { get; set; }
        public string Ext1 { get; set; }
        public byte[] Ext2 { get; set; }
    }
}

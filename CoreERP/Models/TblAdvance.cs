using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAdvance
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string AdvanceType { get; set; }
        public decimal? AdvanceAmount { get; set; }
        public DateTime? ApplyDate { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string Reason { get; set; }
        public string RecommendedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string Status { get; set; }
        public decimal? Balance { get; set; }
        public decimal? DeductedAmount { get; set; }
    }
}

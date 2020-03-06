using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblShift
    {
        public decimal ShiftId { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal? UserId { get; set; }
        public decimal? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public decimal? Status { get; set; }
        public string Narration { get; set; }
    }
}

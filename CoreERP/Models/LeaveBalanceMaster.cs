using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class LeaveBalanceMaster
    {
        public string EmpCode { get; set; }
        public string Year { get; set; }
        public string LeaveCode { get; set; }
        public double? Opbal { get; set; }
        public double? Used { get; set; }
        public string? UserId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public double? Balance { get; set; }
        public string? Remarks { get; set; }
        public string? CompCode { get; set; }
    }
}

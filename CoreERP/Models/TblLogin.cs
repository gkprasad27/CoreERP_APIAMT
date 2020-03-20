using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblLogin
    {
        public decimal LoginId { get; set; }
        public decimal UserId { get; set; }
        public decimal BranchId { get; set; }
        public decimal EmployeeId { get; set; }
        public decimal ShiftId { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Type { get; set; }
    }
}

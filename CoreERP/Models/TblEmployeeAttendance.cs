using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblEmployeeAttendance
    {
        public decimal EmployeeAttendanceId { get; set; }
        public decimal EmployeeMasterId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public decimal DesignationId { get; set; }
        public string DesignationName { get; set; }
        public decimal MonthId { get; set; }
        public string MonthName { get; set; }
        public decimal? TotalWorkingDays { get; set; }
        public decimal? PresentDays { get; set; }
        public decimal? CasualLeaves { get; set; }
        public decimal? LossOfPayDays { get; set; }
        public decimal? SickLeaves { get; set; }
        public decimal? PrivilegeLeaves { get; set; }
        public decimal? TotalPayDays { get; set; }
        public decimal? EOther1 { get; set; }
        public decimal? EOther2 { get; set; }
        public decimal? EOther3 { get; set; }
        public decimal? DOther1 { get; set; }
        public decimal? DOther2 { get; set; }
        public decimal? DOther3 { get; set; }
        public DateTime? ProcessDate { get; set; }
    }
}

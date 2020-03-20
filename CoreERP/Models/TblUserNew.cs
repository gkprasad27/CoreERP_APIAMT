using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblUserNew
    {
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

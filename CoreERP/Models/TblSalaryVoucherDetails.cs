using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSalaryVoucherDetails
    {
        public decimal SalaryVoucherDetailsId { get; set; }
        public decimal? SalaryVoucherMasterId { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? Bonus { get; set; }
        public decimal? Deduction { get; set; }
        public decimal? Advance { get; set; }
        public decimal? Lop { get; set; }
        public decimal? Salary { get; set; }
        public string Status { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

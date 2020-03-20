using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblDailySalaryVoucherDetails
    {
        public decimal DailySalaryVoucherDetailsId { get; set; }
        public decimal? DailySalaryVoucherMasterId { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? Wage { get; set; }
        public string Status { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

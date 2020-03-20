using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSalaryPackage
    {
        public decimal SalaryPackageId { get; set; }
        public string SalaryPackageName { get; set; }
        public bool? IsActive { get; set; }
        public string Narration { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

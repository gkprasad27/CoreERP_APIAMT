using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSalaryPackageDetails
    {
        public decimal SalaryPackageDetailsId { get; set; }
        public decimal? SalaryPackageId { get; set; }
        public decimal? PayHeadId { get; set; }
        public decimal? Amount { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

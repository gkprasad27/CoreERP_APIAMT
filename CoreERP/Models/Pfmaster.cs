using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Pfmaster
    {
        public int Id { get; set; }
        public string? CompanyCode { get; set; }
        public string? BranchCode { get; set; }
        public string? PfName { get; set; }
        public string? Limit { get; set; }
        public string? PfType { get; set; }
        public string? ComponentName { get; set; }
        public double? EmployeeContribution { get; set; }
        public double? EmployerContribution { get; set; }
        public string? ContributionType { get; set; }
        public string? Active { get; set; }
        public double? Amount { get; set; }
    }
}

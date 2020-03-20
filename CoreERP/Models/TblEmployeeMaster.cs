using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblEmployeeMaster
    {
        public decimal EmployeeMasterId { get; set; }
        public decimal BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public decimal? DesignationId { get; set; }
        public string AccountCode { get; set; }
        public DateTime? Dob { get; set; }
        public string FatherName { get; set; }
        public DateTime? AppDate { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string AadharNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string PanNumber { get; set; }
        public string EsiNumber { get; set; }
        public decimal? SpecialPay { get; set; }
        public string PfNumber { get; set; }
        public string MobileNumber { get; set; }
        public decimal? Basic { get; set; }
        public decimal? Da { get; set; }
        public decimal? Hra { get; set; }
        public decimal? Ca { get; set; }
        public decimal? GrossSalary { get; set; }
        public decimal? PfPercentage { get; set; }
        public decimal? EsiPercentage { get; set; }
        public decimal? ProfTax { get; set; }
        public decimal? Lic { get; set; }
        public decimal? Gsli { get; set; }
        public decimal? Csli { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public decimal? EarningOther1 { get; set; }
        public decimal? DeductionOther1 { get; set; }
    }
}

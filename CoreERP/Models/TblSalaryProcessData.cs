using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSalaryProcessData
    {
        public decimal SalaryProcessDataId { get; set; }
        public string SalaryProcessDataVoucherNo { get; set; }
        public decimal EmployeeMasterId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? ProcessDate { get; set; }
        public decimal MonthId { get; set; }
        public string MonthName { get; set; }
        public decimal? Basic { get; set; }
        public decimal? WorkingDays { get; set; }
        public decimal? BankAccountNo { get; set; }
        public decimal? LossOfPay { get; set; }
        public decimal? TotalPayDays { get; set; }
        public decimal? NetSalary { get; set; }
        public decimal SalaryParameterId { get; set; }
        public decimal? EarnedBasic { get; set; }
        public decimal? Da { get; set; }
        public decimal? Hra { get; set; }
        public decimal? Ca { get; set; }
        public decimal? Pp { get; set; }
        public decimal? SpecialAllowance { get; set; }
        public decimal? TotalEarnings { get; set; }
        public decimal? MessAllowance { get; set; }
        public decimal? OtherEarings { get; set; }
        public decimal? ProfitTax { get; set; }
        public decimal? Pf { get; set; }
        public decimal? Fpf { get; set; }
        public decimal? Esi { get; set; }
        public decimal? Lic { get; set; }
        public decimal? Loan1 { get; set; }
        public decimal? Loan2 { get; set; }
        public decimal? Loan3 { get; set; }
        public decimal? Loan4 { get; set; }
        public decimal? TotalDeductions { get; set; }
        public string Areas { get; set; }
        public decimal? PTax { get; set; }
        public decimal? McLoan { get; set; }
        public decimal? Gsli { get; set; }
        public decimal? Csli { get; set; }
        public decimal? Other1 { get; set; }
        public decimal? Other2 { get; set; }
        public decimal? Other3 { get; set; }
        public decimal? Advance { get; set; }
        public decimal? Tds { get; set; }
        public decimal? OtherDeductions { get; set; }
        public string DeductionRemarks { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblEmployee
    {
        public string? BranchId { get; set; }
        public string? DesignationId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeCode { get; set; }
        public DateTime? Dob { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public string? Qualification { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? ReleavingDate { get; set; }
        public bool? IsActive { get; set; }
        public string? Narration { get; set; }
        public string? BloodGroup { get; set; }
        public string? PassportNo { get; set; }
        public string? AccessCardNumber { get; set; }
        public string? EmployeeType { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? IFSCCode { get; set; }
        public string? PanNumber { get; set; }
        public string? PfNumber { get; set; }
        public string? EsiNumber { get; set; }
        public string? AadharNumber { get; set; }
        public string? RecomendedBy { get; set; }
        public string? ReportedBy { get; set; }
        public string? ApprovedBy { get; set; }
        //public string? EmployeeID { get; set; }
        public string? CompanyCode { get; set; }
        public string? DepartmentCode { get; set; }
    }
}

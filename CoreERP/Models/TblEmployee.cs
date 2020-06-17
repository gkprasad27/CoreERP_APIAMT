using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblEmployee
    {
        public decimal EmployeeId { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal? DesignationId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? Dob { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool? IsActive { get; set; }
        public string Narration { get; set; }
        public string BloodGroup { get; set; }
        public string PassportNo { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public string LabourCardNumber { get; set; }
        public DateTime? LabourCardExpiryDate { get; set; }
        public string SalaryType { get; set; }
        public string BankName { get; set; }
        public string BankbranchName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankbranchCode { get; set; }
        public string PanNumber { get; set; }
        public string PfNumber { get; set; }
        public string EsiNumber { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public decimal? DefaultPackageId { get; set; }
        public string AadharNumber { get; set; }
        public string RecomendedBy { get; set; }
        public string RecomendedId { get; set; }
        public string ReportedBy { get; set; }
        public string ApprovedBy { get; set; }
    }
}

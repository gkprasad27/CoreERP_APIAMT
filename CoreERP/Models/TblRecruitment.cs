using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_Recruitment")]
    public partial class TblRecruitment
    {
        public int ID { get; set; }
        public string? EMPCode { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public string? Qualification { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? InterviewDate { get; set; }
        public DateTime? SelectedDate { get; set; }
        public string? Status { get; set; }
        public string? Narration { get; set; }
        public string? BloodGroup { get; set; }
        public string? PassportNo { get; set; }
        public string? PanNumber { get; set; }
        public string? PfNumber { get; set; }
        public string? EsiNumber { get; set; }
        public string? AadharNumber { get; set; }
        public string? RecomendedBy { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

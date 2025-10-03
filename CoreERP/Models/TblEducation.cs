using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_Education")]
    public partial class TblEducation
    {
        public int ID { get; set; }
        public string? EmpCode { get; set; }
        public string? Qualification { get; set; }
        public string? Education { get; set; }
        public string? Percentage { get; set; }
        public DateTime? YearofPassing { get; set; }
        public string? InistituateName { get; set; }
        public string? University { get; set; }
        public string? EducationType { get; set; }
        public string? Specialization { get; set; }
        public string? Attachment { get; set; }
        public string? EducationGap { get; set; }
        public string? Remarks { get; set; }
        public string? EducationGapReasion { get; set; }
        public DateTime? EducationGapFrom { get; set; }
        public DateTime? EducationGapTo { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblEducation
    {
        public string ID { get; set; }
        public string? EmpCode { get; set; }
        public string? Qualification { get; set; }
        public string? Education { get; set; }
        public string? Percentage { get; set; }
        public string? YearofPassing { get; set; }
        public string? InistituateName { get; set; }
        public string? University { get; set; }
        public string? EducationType { get; set; }
        public string? Specialization { get; set; }
        public string? Attachment { get; set; }
        public string? EducationGap { get; set; }
        public string? Remarks { get; set; }
        public string? EducationGapReasion { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }

    }
}

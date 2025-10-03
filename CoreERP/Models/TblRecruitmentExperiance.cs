using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_RecruitmentExperiance")]
    public partial class TblRecruitmentExperiance
    {
        public int ID { get; set; }
        public string? EmpCode { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? TotalExp { get; set; }
        public string? Reasionforleft { get; set; }
        public string? Attachment { get; set; }
        public string? CarrierGap { get; set; }
        public string? CarrierGapReasion { get; set; }
        public DateTime? CarrierGapFrom { get; set; }
        public DateTime? CarrierGapTo { get; set; }
        public string? CarrierGapDays { get; set; }
        public string? Designation { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }

    }
}

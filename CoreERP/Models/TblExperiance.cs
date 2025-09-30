using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblExperiance
    {
        public string ID { get; set; }
        public string? EmpCode { get; set; }
        public string? CompanyName { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
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

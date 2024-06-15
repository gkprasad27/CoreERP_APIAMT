using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class ApprovalType
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Approval { get; set; }
        public string? ImmediateReporting { get; set; }
        public string? RecomendedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public string? Company { get; set; }
        public string? Department { get; set; }
           }
}

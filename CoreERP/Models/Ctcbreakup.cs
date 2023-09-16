using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Ctcbreakup
    {
        public int Id { get; set; }
        public string? CompanyCode { get; set; }
        public string? EmpCode { get; set; }
        public DateTime? EffectFrom { get; set; }
        public string? EarnDednCode { get; set; }
        public double? EarnDednAmount { get; set; }
        public double? Ctc { get; set; }
        public string? Usrid { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? Upload { get; set; }
        public string? Description { get; set; }
        public string? EmpGrp { get; set; }
        public string? EarnDednName { get; set; }
        public string? StructureName { get; set; }
        public string? CycleName { get; set; }
        public string? Duration { get; set; }
        public string? SpecificMonth { get; set; }
        public string? Active { get; set; }
        public string? Ext1 { get; set; }
        public string? Ext2 { get; set; }
    }
}

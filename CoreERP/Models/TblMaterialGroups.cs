using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialGroups
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int groupId { get; set; }
        public string? groupCode { get; set; }
        public string? groupName { get; set; }
        public string? narration { get; set; }
        public string? extra1 { get; set; }
        public string? extra2 { get; set; }
        public DateTime? extraDate { get; set; }
    }
}

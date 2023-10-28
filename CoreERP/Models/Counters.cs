using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Counters")]
    public partial class Counters
    {
        public int Code { get; set; }
        public string? CounterName { get; set; }
        public string? NumberRange { get; set; }
        public string? Prefix { get; set; }
        public string? Suffix { get; set; }
        public string? Active { get; set; }
        public string? Ext1 { get; set; }
        public string? Ext2 { get; set; }
        public int? LastNumber { get; set; }
    }
}

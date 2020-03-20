using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPayHead
    {
        public decimal PayHeadId { get; set; }
        public string PayHeadName { get; set; }
        public string Type { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

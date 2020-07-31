using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSize
    {
        public string SizeId { get; set; }
        public string Size { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
    }
}

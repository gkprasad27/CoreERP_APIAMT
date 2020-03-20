using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblModelNo
    {
        public decimal ModelNoId { get; set; }
        public string ModelNo { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

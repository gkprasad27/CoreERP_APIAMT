using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblProductGroupps
    {
        public decimal GroupId { get; set; }
        public decimal GroupCode { get; set; }
        public string GroupName { get; set; }
        public string Narration { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public DateTime? ExtraDate { get; set; }
    }
}

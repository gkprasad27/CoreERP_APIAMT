using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBrand
    {
        public decimal BrandId { get; set; }
        public string BrandName { get; set; }
        public string Narration { get; set; }
        public string Manufacturer { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public DateTime? ExtraDate { get; set; }
    }
}

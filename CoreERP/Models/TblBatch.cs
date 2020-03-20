using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBatch
    {
        public decimal BatchId { get; set; }
        public string BatchNo { get; set; }
        public decimal? ProductId { get; set; }
        public string Barcode { get; set; }
        public string PartNo { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Narration { get; set; }
    }
}

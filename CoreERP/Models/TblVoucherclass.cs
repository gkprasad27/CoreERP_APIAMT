using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Voucherclass
    {
        public string VoucherCode { get; set; }
        public string? Class { get; set; }
        public string? Ext1 { get; set; }
        public string? Ext2 { get; set; }
        public string? VouchrType { get; set; }
        public string? Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

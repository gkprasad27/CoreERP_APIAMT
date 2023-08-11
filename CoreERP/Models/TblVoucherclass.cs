using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Voucherclass
    {
        public string? VoucherKey { get; set; }
        public string? Description { get; set; }
        public string? Ext1 { get; set; }
        public string? VoucherNature { get; set; }
       public string? Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

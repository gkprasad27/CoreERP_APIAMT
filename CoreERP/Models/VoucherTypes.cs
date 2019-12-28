using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class VoucherTypes
    {
        public string VoucherCode { get; set; }
        public string Branch { get; set; }
        public string Company { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string NoSeries { get; set; }
        public string Period { get; set; }
        public string Prefix { get; set; }
        public string Transaction { get; set; }
        public string VoucherType { get; set; }
    }
}

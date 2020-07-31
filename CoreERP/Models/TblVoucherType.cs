using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVoucherType
    {
        public string VoucherTypeId { get; set; }
        public string VoucherTypeName { get; set; }
        public string PrintText { get; set; }
        public string VoucherClass { get; set; }
    }
}

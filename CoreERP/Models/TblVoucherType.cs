using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVoucherType
    {
        public int? VoucherTypeId { get; set; }
        public string? VoucherTypeName { get; set; }
        public string? voucherClass { get; set; }
        public string? accountType { get; set; }
        public string? printText { get; set; }
        public string? narration { get; set; }
        public string? isActive { get; set; }
        public int? isDefault { get; set; }
       



    }
}

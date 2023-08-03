using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVoucherType
    {
        public int? VoucherTypeId { get; set; }
        public string? VoucherTypeName { get; set; }
        public string? typeOfVoucher { get; set; }
        public string? methodOfVoucherNumbering { get; set; }
        public string? isTaxApplicable { get; set; }
        public string? narration { get; set; }
        public string? isActive { get; set; }
        public int? isDefault { get; set; }
        public int? masterId { get; set; }
        public string? declaration { get; set; }



    }
}

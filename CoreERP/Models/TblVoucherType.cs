using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVoucherType
    {
        public decimal VoucherTypeId { get; set; }
        public string VoucherTypeName { get; set; }
        public string TypeOfVoucher { get; set; }
        public string MethodOfVoucherNumbering { get; set; }
        public bool? IsTaxApplicable { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public int? MasterId { get; set; }
        public string Declaration { get; set; }
        public string Heading1 { get; set; }
        public string Heading2 { get; set; }
        public string Heading3 { get; set; }
        public string Heading4 { get; set; }
    }
}

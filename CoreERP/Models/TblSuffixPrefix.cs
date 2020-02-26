using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSuffixPrefix
    {
        public decimal SuffixprefixId { get; set; }
        public decimal BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? StartIndex { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int? WidthOfNumericalPart { get; set; }
        public bool? PrefillWithZero { get; set; }
        public string Narration { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string BillNumber { get; set; }
    }
}

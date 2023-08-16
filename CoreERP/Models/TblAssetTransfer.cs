using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetTransfer
    {
        public string? Company { get; set; }
        public string? Branch { get; set; }
        public string? VoucherClass { get; set; }
        public string? VoucherType { get; set; }
        public DateTime? VoucherDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? Period { get; set; }
        public string? VoucherNumber { get; set; }
        public string? AssetTransactionType { get; set; }
        public DateTime? TransferDate { get; set; }
        public string? AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        public DateTime? EditDate { get; set; }
        public string? Status { get; set; }
    }
}

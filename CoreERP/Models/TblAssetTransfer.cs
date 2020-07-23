using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetTransfer
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string VoucherClass { get; set; }
        public string VoucherType { get; set; }
        public DateTime? VoucherDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? Period { get; set; }
        public string VoucherNo { get; set; }
        public string AssetTransactionType { get; set; }
        public string MainAsset { get; set; }
        public string SubAsset { get; set; }
        public string SenderBranch { get; set; }
        public string ReceiverBranch { get; set; }
        public string SenderProfitCenter { get; set; }
        public string ReceiverProfitCenter { get; set; }
        public string SenderCostCenter { get; set; }
        public string ReceiverCostCenter { get; set; }
        public string SenderSegment { get; set; }
        public string ReceiverSegment { get; set; }
        public decimal? AcquisitionValue { get; set; }
        public int? AccumulatedDepreciation { get; set; }
        public DateTime? TransferDate { get; set; }
    }
}

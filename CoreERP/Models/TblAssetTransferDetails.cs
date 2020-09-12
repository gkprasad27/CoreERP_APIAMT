using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetTransferDetails
    {
        public int Id { get; set; }
        public string MainAssetNo { get; set; }
        public string SubAssetNo { get; set; }
        public string SenderBranch { get; set; }
        public string SenderProfitCenter { get; set; }
        public string SenderSegment { get; set; }
        public string SenderCostCenter { get; set; }
        public string ReceiverBranch { get; set; }
        public string ReceiverProfitCenter { get; set; }
        public string ReceiverSegment { get; set; }
        public string ReceiverCostCenter { get; set; }
        public string AcquisitionValue { get; set; }
        public string AccumulatedValue { get; set; }
        public string Status { get; set; }
        public string AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string EditWho { get; set; }
        public DateTime? EditDate { get; set; }
        public string VoucherNumber { get; set; }
    }
}

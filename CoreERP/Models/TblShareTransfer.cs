using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblShareTransfer
    {
        public decimal ShareId { get; set; }
        public string ShareTransferCode { get; set; }
        public decimal ShareCode { get; set; }
        public DateTime TransferDate { get; set; }
        public int IsSharesTransfered { get; set; }
        public decimal FromMemberId { get; set; }
        public decimal FromMemberCode { get; set; }
        public string FromMemberName { get; set; }
        public int FromMemberSharesBefore { get; set; }
        public int FromMemberSharesAfter { get; set; }
        public decimal ToMemberId { get; set; }
        public decimal ToMemberCode { get; set; }
        public string ToMemberName { get; set; }
        public int ToMemberSharesBefore { get; set; }
        public int ToMemberSharesAfter { get; set; }
    }
}

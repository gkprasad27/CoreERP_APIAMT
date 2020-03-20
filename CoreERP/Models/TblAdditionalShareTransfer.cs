using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAdditionalShareTransfer
    {
        public decimal AdditionalShareId { get; set; }
        public string AdditionalShareTransferCode { get; set; }
        public decimal AdditionalShareCode { get; set; }
        public DateTime TransferDate { get; set; }
        public int IsAdditionalSharesTransfered { get; set; }
        public int NoOfSharesToTransfer { get; set; }
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

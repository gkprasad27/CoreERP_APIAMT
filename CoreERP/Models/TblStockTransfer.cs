using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockTransfer
    {
        public decimal StockTransferId { get; set; }
        public string TransferNo { get; set; }
        public DateTime? Date { get; set; }
        public decimal BranchId { get; set; }
        public string FromBranch { get; set; }
        public string ToBranch { get; set; }
        public string Narration { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
    }
}

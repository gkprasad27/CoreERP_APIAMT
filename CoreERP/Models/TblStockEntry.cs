using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockEntry
    {
        public decimal StockEntryId { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string VocherNo { get; set; }
        public DateTime? Date { get; set; }
        public string Narration { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
    }
}

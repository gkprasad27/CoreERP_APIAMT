using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblGoodsIssueMaster
    {
        public int GoodsIssueId { get; set; }
        public string? Company { get; set; }
        public string? StoresPerson { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Department { get; set; }
        public string? SaleOrderNumber { get; set; }
        public string? ProductionPerson { get; set; }
        public string? Status { get; set; }
    }
}

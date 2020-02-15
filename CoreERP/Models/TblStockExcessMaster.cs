using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockExcessMaster
    {
        public decimal StockExcessMasterId { get; set; }
        public string StockExcessNo { get; set; }
        public DateTime? StockExcessDate { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string CostCenter { get; set; }
        public decimal? ShiftId { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public decimal? EmployeeId { get; set; }
        public string Narration { get; set; }
        public DateTime? ServerDate { get; set; }
    }
}

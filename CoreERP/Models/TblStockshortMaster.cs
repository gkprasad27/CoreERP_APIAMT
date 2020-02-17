using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockshortMaster
    {
        public decimal StockshortMasterId { get; set; }
        public string StockshortNo { get; set; }
        public DateTime? StockshortDate { get; set; }
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

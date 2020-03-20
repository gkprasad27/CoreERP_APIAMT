using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockEntryMaster
    {
        public decimal StockEntryMasterId { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string StockEntryNo { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public DateTime? StockEntryDate { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public decimal? ShiftId { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public decimal? EmployeeId { get; set; }
        public string Remarks { get; set; }
        public decimal? TotalStockValue { get; set; }
        public string Narration { get; set; }
    }
}

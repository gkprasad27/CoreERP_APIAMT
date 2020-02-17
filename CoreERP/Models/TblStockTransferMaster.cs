using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockTransferMaster
    {
        public decimal StockTransferMasterId { get; set; }
        public string StockTransferNo { get; set; }
        public DateTime? StockTransferDate { get; set; }
        public string FromBranchCode { get; set; }
        public string FromBranchName { get; set; }
        public string ToBranchCode { get; set; }
        public string ToBranchName { get; set; }
        public decimal? ShiftId { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public decimal? EmployeeId { get; set; }
        public string Narration { get; set; }
        public DateTime? ServerDateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOperatorStockIssues
    {
        public decimal OperatorStockIssueId { get; set; }
        public string IssueNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public string FromBranchCode { get; set; }
        public string FromBranchName { get; set; }
        public string ToBranchCode { get; set; }
        public string ToBranchName { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public decimal? ShiftId { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public decimal? EmployeeId { get; set; }
        public string Remarks { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

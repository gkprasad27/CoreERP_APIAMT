using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOperatorStockIssuesDetail
    {
        public decimal? OperatorStockIssueDetailId { get; set; }
        public decimal? OperatorStockIssueId { get; set; }
        public string IssueNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public decimal ProductId { get; set; }
        public decimal HsnNo { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? Rate { get; set; }
        public decimal Qty { get; set; }
        public string BatchNo { get; set; }
        public decimal UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal ProductGroupId { get; set; }
        public decimal ProductGroupCode { get; set; }
        public decimal TaxGroupId { get; set; }
        public string TaxGroupCode { get; set; }
        public string TaxGroupName { get; set; }
        public decimal TaxStructureId { get; set; }
        public decimal TaxStructureCode { get; set; }
        public decimal? Cgst { get; set; }
        public decimal? Sgst { get; set; }
        public decimal? Igst { get; set; }
        public decimal? TotalGst { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? AvailStock { get; set; }
    }
}

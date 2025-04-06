using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblGoodsIssueDetails
    {
        public int Id { get; set; }
        public int? GoodsIssueId { get; set; }
        public int? Qty { get; set; }
        public string? Plant { get; set; }
        public string? Location { get; set; }
        public string? JoborProject { get; set; }
        public string? JobOrder { get; set; }
        public string? CostCenter { get; set; }
        public string? Wbs { get; set; }
        public int? AllocatedQTY { get; set; }
        public string? MaterialCode { get; set; }
         public string? SaleOrderNumber { get; set; }
        public string? MaterialName { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public string? Status { get; set; }
        public DateTime? ProductionPlanDate { get; set; }
        public DateTime? ProductionTargetDate { get; set; }
        public string? BomNumber { get; set; }
        public string? BomName { get; set; }
        public string? MainComponent { get; set; }
        public string? ApprovalStatus { get; set; }
    }
}

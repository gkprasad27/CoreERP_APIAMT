using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblWorkcenterMaster
    {
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? WorkcenterType { get; set; }
        public string? WorkcenterCode { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Person { get; set; }
        public string? Usage { get; set; }
        public string? AutopostingGoods { get; set; }
        public string? Scheduling { get; set; }
        public string? CostDerivation { get; set; }
        public string? CapacityReqirement { get; set; }
        public string? GoodsReceiptPosting { get; set; }
        public string? QualityInspection { get; set; }
        public decimal? MoveTime { get; set; }
        public decimal? WaitTime { get; set; }
        public decimal? QueueTime { get; set; }
        public decimal? SetupTime { get; set; }
        public decimal? RunTimeforEachUnit { get; set; }
        public decimal? LeadTime { get; set; }
    }
}

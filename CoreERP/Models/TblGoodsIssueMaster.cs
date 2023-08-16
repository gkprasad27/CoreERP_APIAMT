using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblGoodsIssueMaster
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int GoodsIssueId { get; set; }
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? StoresPerson { get; set; }
        public string? Department { get; set; }
        public string? RequisitionNumber { get; set; }
        public string? MovementType { get; set; }
        public string? Status { get; set; }
    }
}

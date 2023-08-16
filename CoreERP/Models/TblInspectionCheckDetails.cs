using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInspectionCheckDetails
    {
        public int Id { get; set; }
        public string? InspectionCheckNo { get; set; }
        public string? MaterialCode { get; set; }
        public string? Description { get; set; }
        public int? ReceivedQty { get; set; }
        public int? RejectedQty { get; set; }
        public string? Location { get; set; }
        public string? MovementTo { get; set; }
        public string? RejectReason { get; set; }
    }
}

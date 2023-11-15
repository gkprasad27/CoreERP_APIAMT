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
        public string? ProductTag { get; set; }
        public string? Status { get; set; }
        public string? SaleorderNo { get; set; }
        public string? CompletedBy { get; set; }
        public string? Addwho { get; set; }
        public string? Editwho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string? InspectionType { get; set; }
    }
}

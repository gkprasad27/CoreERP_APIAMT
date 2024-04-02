using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblInspectionCheckDetails
    {
        public int Id { get; set; }
        public string? InspectionCheckNo { get; set; }
        public string? MaterialCode { get; set; }
        public string? Description { get; set; }
        public string? productionTag { get; set; }
        public string? Status { get; set; }
        public string? saleOrderNumber { get; set; }
        public string? CompletedBy { get; set; }
        public string? Addwho { get; set; }
        public string? Editwho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public DateTime? CompletionDate { get; set; }
       [ DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public string? InspectionType { get; set; }
        public string? HeatNumber { get; set; }
        public string? PartDrgNo { get; set; }
        public string? DrawingRevNo { get; set; }
        public string? BomKey { get; set; }
        public string? BomName { get; set; }

    }
}

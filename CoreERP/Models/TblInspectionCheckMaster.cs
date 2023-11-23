using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInspectionCheckMaster
    {
        public string InspectionCheckNo { get; set; }
        public string? Company { get; set; }
        public string? saleOrderNumber { get; set; }
        public string? InspectionType { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Status { get; set; }
        public string? AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? completionDate { get; set; }
        public string? completedBy { get; set; }
        public string? MaterialCode { get; set; }
        public string? productionTag { get; set; }
        public string? description { get; set; }
    }
}

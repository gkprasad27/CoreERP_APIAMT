using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseRequisitionDetails
    {
        public int Id { get; set; }
        public string PurchaseRequisitionNumber { get; set; }
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public int? RequiredQty { get; set; }
        public int? StockQty { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string PurchaseGroup { get; set; }
        public string ProductionOrder { get; set; }
        public string ReservationNumber { get; set; }
        public string Narration { get; set; }
        public string AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string EditWho { get; set; }
        public DateTime? EditDate { get; set; }
        public string RecommendedBy { get; set; }
        public DateTime? RecommendedDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Status { get; set; }
    }
}

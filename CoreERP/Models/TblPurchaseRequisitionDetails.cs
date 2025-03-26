using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblPurchaseRequisitionDetails
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? PurchaseRequisitionNumber { get; set; }
        public string? MaterialCode { get; set; }
        public string? MaterialName { get; set; }
        public string? Description { get; set; }
        public int? Qty { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string? PurchaseGroup { get; set; }
        public string? ProductionOrder { get; set; }
        public string? ReservationNumber { get; set; }
        public string? Narration { get; set; }
        public string? AddWho { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public string? RecommendedBy { get; set; }
        public DateTime? RecommendedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Status { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? Total { get; set; }
        public int? POQty { get; set; }
        public string? Company { get; set; }
    }
}

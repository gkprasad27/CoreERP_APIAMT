using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblGoodsReceiptMaster
    {
        public int Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? Branch { get; set; }
        public string? ProfitCenter { get; set; }
        public string? SupplierCode { get; set; }
        public string? SupplierReferenceNo { get; set; }
        public string? Rrno { get; set; }
        public string? VehicleNo { get; set; }
        public string? SupplierGinno { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? ReceivedBy { get; set; }
        public string? MovementType { get; set; }
        public string? Grnno { get; set; }
        public string? QualityCheck { get; set; }
        public string? StorageLocation { get; set; }
        public string? InspectionNoteNo { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ReceiptDate { get; set; }
        public DateTime? Grndate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }
        public string? LotNo { get; set; }
        public string? customerName { get; set; }
        public string? InvoiceURL { get; set; }
        public string? DocumentURL { get; set; }
        public string? CompanyName { get; set; }
        public string? ProfitcenterName { get; set; }
        public string? SaleorderNo { get; set; }
        public string? ApprovedBy { get; set; }
        public string? RecommendedBy { get; set; }
        public string? ApprovalStatus { get; set; }
        public decimal? Fright { get; set; }
        public decimal? WeightBridge { get; set; }
        public decimal? OtherCharges { get; set; }
        public decimal? HamaliCharges { get; set; }
        public decimal? RoundOff { get; set; }

    }
}

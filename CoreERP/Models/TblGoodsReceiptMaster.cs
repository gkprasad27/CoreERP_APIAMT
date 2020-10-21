using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblGoodsReceiptMaster
    {
        public int Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string Company { get; set; }
        public string Plant { get; set; }
        public string Branch { get; set; }
        public string ProfitCenter { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierReferenceNo { get; set; }
        public string Rrno { get; set; }
        public string VehicleNo { get; set; }
        public string SupplierGinno { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string ReceivedBy { get; set; }
        public string MovementType { get; set; }
        public string Grnno { get; set; }
        public string QualityCheck { get; set; }
        public string StorageLocation { get; set; }
        public string InspectionNoteNo { get; set; }
        public string AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string EditWho { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? ReceiptDate { get; set; }
    }
}

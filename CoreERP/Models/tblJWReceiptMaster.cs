using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_JWReceiptMaster")]
    public partial class tblJWReceiptMaster
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public string? ProfitCenter { get; set; }
        public string? JobWorkNumber { get; set; }
        public string? Vendor { get; set; }
        public string? VehicleNo { get; set; }

        public DateTime? ReceivedDate { get; set; }
        public string? ReceivedBy { get; set; }
        public decimal? TotalWeight { get; set; }
        public string? LotNo { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public string? VendorGSTN { get; set; }
        public string? InvoiceNumber { get; set; }

    }
}

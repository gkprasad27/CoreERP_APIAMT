using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_JWReceiptDetails")]
    public partial class tblJWReceiptDetails
    {
        public int ID { get; set; }
        public string? JobWorkNumber { get; set; }
        public string? MaterialCode { get; set; }
        public decimal? Weight { get; set; }
        public int? RejectedQty { get; set; }
        public int? ReceivedQty { get; set; }
        public string? LotNo { get; set; }
        public DateTime? ReceivedDate { get; set; }

        public string? VehicleNo { get; set; }
        public string? InvoiceNo { get; set; }
        public decimal? BillAmount { get; set; }
        public string? DocumentURL { get; set; }
        public string? ReceivedBy { get; set; }
        public string? Status { get; set; }

        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }


        public string? InvoiceDocument { get; set; }

    }
}

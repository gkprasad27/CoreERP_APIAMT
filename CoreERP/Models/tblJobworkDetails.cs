using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_JobworkDetails")]
    public partial class tblJobworkDetails
    {
        public int ID { get; set; }
        public string? JobworkNumber { get; set; }
        public string? MaterialCode { get; set; }
        public int? Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Discount { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }       
        public string? Status { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Total { get; set; }
        public string? TaxCode { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? Igst { get; set; }
        public decimal? Cgst { get; set; }
        public decimal? Ugst { get; set; }
        public decimal? Sgst { get; set; }
        public string? Uom { get; set; }
        public string? HsnSac { get; set; }

    }
}

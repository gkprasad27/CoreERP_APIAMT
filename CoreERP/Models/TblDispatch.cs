using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_Dispatch")]
    public partial class TblDispatch
    {
        public int ID { get; set; }
        public string? LRNumber { get; set; }
        public string? SaleOrder { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? LRDate { get; set; }
        public string? Transporter { get; set; }
        public int? Boxes { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }

        public string? ImageURL { get; set; }
        public string? PONumber { get; set; }

    }
}

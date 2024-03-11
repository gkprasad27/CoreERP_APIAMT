using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_PoQueue")]
    public partial class TblPoQueue
    {
        public int ID { get; set; }
        public string? SaleOrderNo { get; set; }
        public string? MaterialCode { get; set; }
        public int? Qty { get; set; }       
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public string? Status { get; set; }
        public string? CompanyCode { get; set; }
    }
}

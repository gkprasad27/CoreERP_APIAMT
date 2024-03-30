using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_productionMaster")]
    public partial class TblProductionMaster
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? Company { get; set; }
        public string? ProfitCenter { get; set; }
        public string SaleOrderNumber { get; set; }
        public string? Status { get; set; }
        public string? Product { get; set; }
       // public string? CompanyName { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }

        public string? CustomerCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_productionMaster")]
    public partial class TblProductionMaster
    {
        public int ID { get; set; }
        public string? Company { get; set; }
        public string? ProfitCenter { get; set; }
        public string? SaleOrderNumber { get; set; }
        public string? Status { get; set; }
        public DateTime? ProductionPlanDate { get; set; }
        public DateTime? ProductionEndDate { get; set; }
        public string? Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_MaterialIssueDetails")]
    public partial class TblMaterialIssueDetails
    {
        public int ID { get; set; }
        public string? MaterialIssueId { get; set; }
        public string? MaterialCode { get; set; }
        public string? MaterialName { get; set; }
        public int Qty { get; set; }
        public DateTime EditDate { get; set; }
        public string? EditWho { get; set; }
        public DateTime AddDate { get; set; }
        public string? AddWho { get; set; }
        public string? Status { get; set; }
        
    }
}

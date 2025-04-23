using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_MaterialIssueMaster")]
    public partial class TblMaterialIssueMaster
    {
       
        public int Id { get; set; }
        public string? MaterialIssueId { get; set; }
        public string? Company { get; set; }
        public string? IssuedFrom { get; set; }
        public string? IssuedTo { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string? Narration { get; set; }
        public DateTime? AddDate { get; set; }
        public string? AddWho { get; set; }
        public DateTime? EditDate { get; set; }
        public string? EditWho { get; set; }
        public string? Status { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_FinanceialStatement")]
    public partial class TblFinanceialStatement
    {
        public int ID { get; set; }
        public string? StructureKey { get; set; }
        public string? StructureName { get; set; }
        public string? Ext { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

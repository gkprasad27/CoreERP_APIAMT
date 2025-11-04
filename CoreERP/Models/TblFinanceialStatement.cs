using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
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

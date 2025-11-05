using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class AssignmentSubaccounttoGl
    {
        public int ID { get; set; }
        public string? CompCode { get; set; }
        public string? Glgroup { get; set; }
        public string? SubAccount { get; set; }
        public string? FromGl { get; set; }
        public string? ToGl { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public string? Ext1 { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }

    }
}

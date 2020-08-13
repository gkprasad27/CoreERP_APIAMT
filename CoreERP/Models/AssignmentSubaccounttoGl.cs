using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class AssignmentSubaccounttoGl
    {
        public int Code { get; set; }
        public string Glgroup { get; set; }
        public string SubAccount { get; set; }
        public string FromGl { get; set; }
        public string ToGl { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblReqNoAssignment
    {
        public string? numberRange { get; set; }
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? Department { get; set; }
        public int? CurrentNumber { get; set; }
    }
}

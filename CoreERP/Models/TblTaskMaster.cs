using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTaskMaster
    {
        public string? Wbselement { get; set; }
        public string? TaskNumber { get; set; }
        public string? Description { get; set; }
        public string? ImmediatePrecedessors { get; set; }
        public string? SuccessorTask { get; set; }
        public int? TimeNeeded { get; set; }
        public int? Period { get; set; }
        public int? EarlyStart { get; set; }
        public int? EarlyFinish { get; set; }
        public int? LateStart { get; set; }
        public int? LateFinish { get; set; }
        public int? ForwardTotal { get; set; }
        public int? BackwardTotal { get; set; }
        public string? Person { get; set; }
        public string? Risk { get; set; }
    }
}

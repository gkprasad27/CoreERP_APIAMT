using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblShiftTimings
    {
        public decimal ShiftTimeId { get; set; }
        public DateTime? ShiftStart { get; set; }
        public DateTime? ShiftEnd { get; set; }
        public string ShiftDescription { get; set; }
        public bool? IsActive { get; set; }
        public string Narration { get; set; }
    }
}

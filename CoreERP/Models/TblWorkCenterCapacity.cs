using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblWorkCenterCapacity
    {
        public string? WorkCenterCode { get; set; }
        public string? Resource { get; set; }
        public string? Capacity { get; set; }
        public decimal? WorkingHours { get; set; }
        public decimal? BreakTime { get; set; }
        public decimal? NetHours { get; set; }
        public int? Shifts { get; set; }
        public decimal? TotalCapacity { get; set; }
        public int? WeekDays { get; set; }
        public int? HoursPerWeek { get; set; }
    }
}

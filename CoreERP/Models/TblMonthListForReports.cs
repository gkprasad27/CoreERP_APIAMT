using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMonthListForReports
    {
        public decimal MonthId { get; set; }
        public string MonthName { get; set; }
        public DateTime? Fromdt { get; set; }
        public DateTime? Todt { get; set; }
    }
}

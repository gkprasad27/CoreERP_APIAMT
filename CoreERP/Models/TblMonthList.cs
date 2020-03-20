using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMonthList
    {
        public decimal MonthId { get; set; }
        public string MonthName { get; set; }
        public decimal? NoOfDays { get; set; }
    }
}

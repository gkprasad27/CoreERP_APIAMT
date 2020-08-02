using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblUnit
    {
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public string Narration { get; set; }
        public int? NoOfDecimalplaces { get; set; }
    }
}

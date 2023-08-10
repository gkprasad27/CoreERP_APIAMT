using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblLotSeries
    {
        public string? SeriesKey { get; set; }
        public string? Description { get; set; }
        public int? FromInterval { get; set; }
        public int? ToInterval { get; set; }
        public int? CurrentLot { get; set; }
        public string? Prefix { get; set; }
    }
}

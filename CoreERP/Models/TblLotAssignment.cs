using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblLotAssignment
    {
        public string LotSeries { get; set; }
        public string Company { get; set; }
        public string Plant { get; set; }
        public string MaterialType { get; set; }
        public int? CurrentNumber { get; set; }
    }
}

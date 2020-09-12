using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblGinnoSeries
    {
        public string Ginseries { get; set; }
        public string Description { get; set; }
        public int? FromInterval { get; set; }
        public int? Tointerval { get; set; }
        public int? CurrentNumber { get; set; }
        public string Prefix { get; set; }
    }
}

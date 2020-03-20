using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblShareValue
    {
        public decimal ShareValueId { get; set; }
        public decimal? ValueOfSingleShare { get; set; }
        public decimal? SharePercentage { get; set; }
    }
}

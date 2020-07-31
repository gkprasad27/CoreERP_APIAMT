using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetNumberRange
    {
        public string Code { get; set; }
        public decimal? FromRange { get; set; }
        public decimal? ToRange { get; set; }
        public string NonNumeric { get; set; }
        public string Description { get; set; }
    }
}

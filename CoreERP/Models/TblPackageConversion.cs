using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPackageConversion
    {
        public decimal PackingConversionId { get; set; }
        public decimal InputProductId { get; set; }
        public string InputproductCode { get; set; }
        public string InputproductName { get; set; }
        public decimal OutputProductId { get; set; }
        public string OutputproductCode { get; set; }
        public string OutputproductName { get; set; }
        public decimal InputQty { get; set; }
        public decimal OutputQty { get; set; }
    }
}

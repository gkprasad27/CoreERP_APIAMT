using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblProductPacking
    {
        public decimal PackingId { get; set; }
        public string PackingCode { get; set; }
        public string PackingName { get; set; }
        public int BatchVerify { get; set; }
        public int BarrelVerify { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTanks
    {
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int TankId { get; set; }
        public string TankNo { get; set; }
        public decimal? TankCapacityinLtrs { get; set; }
        public decimal? NoofPumps { get; set; }
        public int? IsWorking { get; set; }
        public string ProductCode { get; set; }
        public string ItemCode { get; set; }
    }
}

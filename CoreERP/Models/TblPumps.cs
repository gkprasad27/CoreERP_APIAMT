using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPumps
    {
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal? ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? TankId { get; set; }
        public decimal? TankNo { get; set; }
        public decimal PumpId { get; set; }
        public decimal? PumpNo { get; set; }
        public decimal? PumpCapacityinLtrs { get; set; }
        public decimal? MeterReading { get; set; }
        public int? IsWorking { get; set; }
    }
}

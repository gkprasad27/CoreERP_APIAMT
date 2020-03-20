using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMeterReading
    {
        public decimal MeterReadingId { get; set; }
        public decimal BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal ShiftId { get; set; }
        public decimal PumpId { get; set; }
        public decimal PumpNo { get; set; }
        public decimal? Testing { get; set; }
        public decimal? Density { get; set; }
        public decimal? Consumption { get; set; }
        public decimal? InMeterReading { get; set; }
        public decimal? OutMeterReading { get; set; }
        public decimal? TotalSales { get; set; }
        public decimal? InvoiceSales { get; set; }
        public decimal? Variation { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}

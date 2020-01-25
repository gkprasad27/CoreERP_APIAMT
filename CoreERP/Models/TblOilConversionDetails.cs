using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOilConversionDetails
    {
        public decimal OilConversionDetailId { get; set; }
        public decimal? OilConversionMasterId { get; set; }
        public DateTime? OilConversionDetailsDate { get; set; }
        public DateTime? ServerDateTime { get; set; }
        public decimal ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal HsnNo { get; set; }
        public decimal UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal? Rate { get; set; }
        public decimal Qty { get; set; }
        public decimal DamageQty { get; set; }
        public decimal NewQty { get; set; }
        public string BatchNo { get; set; }
        public decimal GrossAmount { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

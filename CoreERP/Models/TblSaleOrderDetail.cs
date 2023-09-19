using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSaleOrderDetail
    {

        public int ID { get; set; }
        public int? SaleOrderNo { get; set; }
        public string? MaterialCode { get; set; }
        public int? QTY { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}

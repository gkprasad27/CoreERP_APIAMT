using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_saleOrderDetail")]
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
        public string? TaxCode { get; set; }
    }
}

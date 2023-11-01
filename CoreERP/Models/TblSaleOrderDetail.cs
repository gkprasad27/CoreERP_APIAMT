using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_saleOrderDetail")]
    public partial class TblSaleOrderDetail
    {

        public int ID { get; set; }
        public string? SaleOrderNo { get; set; }
        public string? MaterialCode { get; set; }
        public string? MaterialName { get; set; }
        public int? QTY { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? IGST { get; set; }
        public decimal? UGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? Total { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? TaxCode { get; set; }
        public decimal? NetWeight { get; set; }
    }
}

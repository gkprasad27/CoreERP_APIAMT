using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSupplierQuotationDetails
    {
        public int Id { get; set; }
        public string QuotationNumber { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public int? Qty { get; set; }
        public decimal? Price { get; set; }
        public int? Unit { get; set; }
        public int? Discount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? Tax { get; set; }
    }
}

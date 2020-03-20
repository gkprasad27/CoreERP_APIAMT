using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class View1
    {
        public string VoucherTypeName { get; set; }
        public string VoucherNo { get; set; }
        public string ProductName { get; set; }
        public decimal? InwardQty { get; set; }
        public decimal? OutwardQty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? GroupId { get; set; }
        public decimal? LedgerId { get; set; }
        public string Expr1 { get; set; }
        public DateTime? Date { get; set; }
    }
}

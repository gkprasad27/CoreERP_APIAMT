using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblQuotationAnalysisDetails
    {
        public int Id { get; set; }
        public string QuotationNumber { get; set; }
        public string MaterialCode { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetPrice { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Total { get; set; }
        public string Delivery { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Advance { get; set; }
    }
}

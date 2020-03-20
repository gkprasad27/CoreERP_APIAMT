using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAdditionalCost
    {
        public decimal AdditionalCostId { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public string VoucherNo { get; set; }
        public decimal? LedgerId { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

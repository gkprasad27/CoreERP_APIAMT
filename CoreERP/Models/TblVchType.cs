using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVchType
    {
        public decimal VoucherTypeId { get; set; }
        public string VoucherTypeName { get; set; }
        public decimal? Parent { get; set; }
        public decimal? SplType { get; set; }
        public decimal? CashBank { get; set; }
    }
}

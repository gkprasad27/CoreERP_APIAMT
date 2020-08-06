using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPaymentTerms
    {
        public string Code { get; set; }
        public int? Days { get; set; }
        public int? Discount { get; set; }
        public string Narration { get; set; }
    }
}

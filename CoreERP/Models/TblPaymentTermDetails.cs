using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPaymentTermDetails
    {
        public int? Id { get; set; }
        public string? PaymentTermCode { get; set; }
        public int? Days { get; set; }
        public int? Discount { get; set; }
        public string? Ext { get; set; }
    }
}

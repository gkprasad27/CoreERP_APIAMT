using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPaymentTermDetails
    {
        public int Id { get; set; }
        public string PaymentTermCode { get; set; }
        public string Days { get; set; }
        public string Discount { get; set; }
        public string Ext { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Smsstatus
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Branch { get; set; }
        public string Mobile { get; set; }
        public string VehicleRegNo { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
        public int? Status { get; set; }
        public string SmsReturnId { get; set; }
    }
}

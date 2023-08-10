using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSupplierTermsAndConditons
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? DeliveryPeriod { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? DeliveryMethod { get; set; }
        public string? DeliveryPlace { get; set; }
        public string? ContactPerson { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CreditPeriod { get; set; }
        public decimal? Advance { get; set; }
    }
}

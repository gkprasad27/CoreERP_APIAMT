using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialSupplierDetails
    {
        public int Id { get; set; }
        public string? SupplierCode { get; set; }
        public string? MaterialCode { get; set; }
        public string? Description { get; set; }
        public decimal? PriceperUnit { get; set; }
        public int? Unit { get; set; }
        public decimal? LastSupplyPrice { get; set; }
        public DateTime? LastSupplyOn { get; set; }
        public string? Ponumber { get; set; }
        public DateTime? Podate { get; set; }
        public string? Narration { get; set; }
        public string? DeliveryDays { get; set; }
        public string? PaymentDueDays { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialPurchasePrice
    {
        public int Id { get; set; }
        public string MaterialCode { get; set; }
        public string Grnnumber { get; set; }
        public DateTime? Grndate { get; set; }
        public string Ponumber { get; set; }
        public DateTime? Podae { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? Unit { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string SupplierCode { get; set; }
    }
}

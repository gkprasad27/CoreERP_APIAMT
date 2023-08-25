using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchasePerson
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? PurchasePerson { get; set; }
        public string? Description { get; set; }
        public string? PurchaseGroup { get; set; }
        public string? PurchaseTypes { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseOrderType
    {
        public string PurchaseOrderType { get; set; }
        public string? Description { get; set; }
        public string? PrintText { get; set; }
    }
}

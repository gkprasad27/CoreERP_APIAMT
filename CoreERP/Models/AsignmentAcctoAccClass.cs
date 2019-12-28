using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class AsignmentAcctoAccClass
    {
        public string Code { get; set; }
        public string AccClass { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string InventoryAcc { get; set; }
        public string PurchaseAcc { get; set; }
        public string SaleAcc { get; set; }
        public string TransactionType { get; set; }
    }
}

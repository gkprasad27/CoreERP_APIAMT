using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Inventory
    {
        public string Code { get; set; }
        public string Account { get; set; }
        public string BranchCode { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string CompCode { get; set; }
        public string Drcrindicator { get; set; }
        public string Empcode { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Model { get; set; }
        public string Narration { get; set; }
        public string OtherExpences { get; set; }
        public string PurchaseValue { get; set; }
        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string ReceivingUnit { get; set; }
        public DateTime ReferenceDate { get; set; }
        public string ReferenceNo { get; set; }
        public string SaleValue { get; set; }
        public string SendingUnit { get; set; }
        public string Size { get; set; }
        public string SubGlacc { get; set; }
        public string TransactionType { get; set; }
        public string Uom { get; set; }
        public string Value { get; set; }
        public string MaterialTranType { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

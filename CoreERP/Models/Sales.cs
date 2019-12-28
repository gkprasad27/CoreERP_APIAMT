using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Sales
    {
        public string Code { get; set; }
        public string Account { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime BillDate { get; set; }
        public string BillNo { get; set; }
        public string BranchCode { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string Cgst { get; set; }
        public string CardType { get; set; }
        public string CompCode { get; set; }
        public string CustName { get; set; }
        public string Discount { get; set; }
        public string Empcode { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool Exchange { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Hsncode { get; set; }
        public string Igst { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string MaterialTranType { get; set; }
        public string Model { get; set; }
        public string ModeofSale { get; set; }
        public string Narration { get; set; }
        public string NetAmount { get; set; }
        public string NetAmtReceived { get; set; }
        public string PhoneNo { get; set; }
        public string Place { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Sgst { get; set; }
        public string Size { get; set; }
        public string TaxBaseAmount { get; set; }
        public string TaxCode { get; set; }
        public string Ugst { get; set; }
        public string Active { get; set; }
    }
}

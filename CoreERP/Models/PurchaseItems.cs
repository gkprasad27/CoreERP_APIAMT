using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class PurchaseItems
    {
        public string Code { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public string Adjusted { get; set; }
        public string BranchCode { get; set; }
        public DateTime ChequeDate { get; set; }
        public string ChequeNo { get; set; }
        public string CompCode { get; set; }
        public string Empcode { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public DateTime GoodsReceiptDate { get; set; }
        public string GoodsReceiptNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string ItemCode { get; set; }
        public DateTime ItemDate { get; set; }
        public string ItemName { get; set; }
        public string Narration { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentReference { get; set; }
        public string VendorAccount { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherNo { get; set; }
        public string Active { get; set; }
    }
}

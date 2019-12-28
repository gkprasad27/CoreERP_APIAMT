using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class VendorPayments
    {
        public string Code { get; set; }
        public string Account { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public string Amount { get; set; }
        public string BranchCode { get; set; }
        public DateTime ChequeDate { get; set; }
        public string ChequeNo { get; set; }
        public string CompCode { get; set; }
        public string Empcode { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Narration { get; set; }
        public string PayementNo { get; set; }
        public string Reference { get; set; }
        public string Type { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherNo { get; set; }
        public string CustomerAccount { get; set; }
        public string PartyNo { get; set; }
        public string Active { get; set; }
    }
}

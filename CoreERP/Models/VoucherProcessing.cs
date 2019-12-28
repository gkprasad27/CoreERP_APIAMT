using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class VoucherProcessing
    {
        public string VoucherNo { get; set; }
        public string Account { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public string Amount { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public DateTime CheckDate { get; set; }
        public string CheckNo { get; set; }
        public string Company { get; set; }
        public string CustAccount { get; set; }
        public string Division { get; set; }
        public string DrCr { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string ExtVoucherNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Narration { get; set; }
        public DateTime RefDate { get; set; }
        public string RefNo { get; set; }
        public string SubAccount { get; set; }
        public string Transaction { get; set; }
        public string TransactionType { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherType { get; set; }
        public string Active { get; set; }
    }
}

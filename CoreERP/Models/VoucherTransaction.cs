using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class VoucherTransaction
    {
        public string TransactionId { get; set; }
        public string AccYear { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public string Amount { get; set; }
        public string BanTaxAmt { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string Cgst { get; set; }
        public string Cgstacc { get; set; }
        public DateTime CheckDate { get; set; }
        public string CheckNo { get; set; }
        public DateTime ChkClrDate { get; set; }
        public string Company { get; set; }
        public string CustAccount { get; set; }
        public string DrCr { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string ExtVoucherNo { get; set; }
        public string Glaccount { get; set; }
        public string GlsubCode { get; set; }
        public string Hsncode { get; set; }
        public string Igst { get; set; }
        public string Igstacc { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Narration { get; set; }
        public string OffSettingAcc { get; set; }
        public string RefNo { get; set; }
        public string Sgst { get; set; }
        public string Sgstacc { get; set; }
        public string TaxCode { get; set; }
        public string Ugst { get; set; }
        public string Ugstacc { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherNo { get; set; }
        public string VoucherType { get; set; }
        public string Active { get; set; }
    }
}

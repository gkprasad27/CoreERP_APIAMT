using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPosaleAssetInvoiceMemoHeader
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string VoucherClass { get; set; }
        public string VoucherType { get; set; }
        public DateTime? VoucherDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? Period { get; set; }
        public string VoucherNumber { get; set; }
        public string TransactionType { get; set; }
        public string AssetTransactionType { get; set; }
        public string Bpcategory { get; set; }
        public string PartyAccount { get; set; }
        public string AccountingIndicator { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public string PartyInvoiceNo { get; set; }
        public string PartyInvoiceDate { get; set; }
        public string Grnno { get; set; }
        public DateTime? Grndate { get; set; }
        public string PaymentItem { get; set; }
        public string Term1 { get; set; }
        public string Term2 { get; set; }
        public string Term3 { get; set; }
        public string Term4 { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TaxAmount { get; set; }
        public string Narration { get; set; }
        public string Ext { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInvoiceMemoHeader
    {
        public string Company { get; set; }
        public string Branch { get; set; }
        public string VoucherClass { get; set; }
        public string VoucherType { get; set; }
        public DateTime? VoucherDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? Period { get; set; }
        public string VoucherNumber { get; set; }
        public string TransactionType { get; set; }
        public string NatureofTransaction { get; set; }
        public string Bpcategory { get; set; }
        public string PartyAccount { get; set; }
        public string AccountingIndicator { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public string PartyInvoiceNo { get; set; }
        public string PartyInvoiceDate { get; set; }
        public string Grnno { get; set; }
        public DateTime? Grndate { get; set; }
        public string Paymentterms { get; set; }
        public decimal? ToalAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public string Narration { get; set; }
        public string Ext { get; set; }
    }
}

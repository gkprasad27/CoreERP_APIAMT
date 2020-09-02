using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblJvmaster
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
        public string ReferenceNo { get; set; }
        public string ReferenceDate { get; set; }
        public string Narration { get; set; }
        public string Ext { get; set; }
        public string Ext1 { get; set; }
        public string AccountingIndicator { get; set; }
    }
}

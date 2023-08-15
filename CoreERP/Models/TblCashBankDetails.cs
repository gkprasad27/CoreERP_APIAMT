using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCashBankDetails
    {
        public int ID { get; set; }
        public string? Company { get; set; }
        public string? Branch { get; set; }
        public string? VoucherNumber { get; set; }
        public DateTime? VoucherDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public string? LineItemNo { get; set; }
        public string? Glaccount { get; set; }
        public string? Bttypes { get; set; }
        public decimal? Amount { get; set; }
        public string? TaxCode { get; set; }
        public decimal? Sgstamount { get; set; }
        public decimal? Cgstamount { get; set; }
        public decimal? Igstamount { get; set; }
        public decimal? Ugstamount { get; set; }
        public string? ReferenceNo { get; set; }
        public string? ReferenceDate { get; set; }
        public string? FunctionalDept { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Segment { get; set; }
        public string? CostCenter { get; set; }
        public string? WorkBreakStructureElement { get; set; }
        public string? NetWork { get; set; }
        public string? OrderNo { get; set; }
        public string? FundCenter { get; set; }
        public string? Commitment { get; set; }
        public string? Hsnsaccode { get; set; }
        public string? Narration { get; set; }
        public string? AccountingIndicator { get; set; }
        public string? Status { get; set; }
        public string? Ext { get; set; }
        public string? AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

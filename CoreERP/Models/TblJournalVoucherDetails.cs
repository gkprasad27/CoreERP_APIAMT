using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblJournalVoucherDetails
    {
        public decimal JournalVoucherDetailsId { get; set; }
        public decimal? JournalVoucherMasterId { get; set; }
        public DateTime? JournalVoucherDetailsDate { get; set; }
        public decimal? ToLedgerId { get; set; }
        public string ToLedgerName { get; set; }
        public string ToLedgerCode { get; set; }
        public decimal? Amount { get; set; }
    }
}

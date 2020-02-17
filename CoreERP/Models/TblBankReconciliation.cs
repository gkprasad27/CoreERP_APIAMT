using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBankReconciliation
    {
        public decimal ReconcileId { get; set; }
        public decimal? LedgerPostingId { get; set; }
        public DateTime? StatementDate { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

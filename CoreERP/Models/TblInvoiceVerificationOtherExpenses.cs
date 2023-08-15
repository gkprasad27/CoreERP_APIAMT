using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInvoiceVerificationOtherExpenses
    {
        public int Id { get; set; }
        public string? PurchaseOrderNo { get; set; }
        public string? Account { get; set; }
        public decimal? Amount { get; set; }
        public string? Drcr { get; set; }
        public string? Plant { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Segment { get; set; }
        public string? Branch { get; set; }
        public string? Description { get; set; }
    }
}

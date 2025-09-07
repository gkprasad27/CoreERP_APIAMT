using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class tbllotwisematerial
    {
        public int Id { get; set; }
        public string? LotNo { get; set; }
        public string? Materialcode { get; set; }
        public int? ReceivedQty { get; set; }
        public int? RejectedQty { get; set; }
        public string? InvoiceNo { get; set; }
        public string? Vendor { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public decimal? Amount { get; set; }

    }
}

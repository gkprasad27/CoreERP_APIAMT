using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInvoiceVerificationDetails
    {
        public int Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Unit { get; set; }
        public int? Qty { get; set; }
        public decimal? Value { get; set; }
        public string Plant { get; set; }
        public string AccountKey { get; set; }
        public string AccountKeyAccount { get; set; }
        public decimal? OtherExpenses { get; set; }
        public string OtherExpensesAccount { get; set; }
    }
}

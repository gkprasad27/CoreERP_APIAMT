using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStockInformation
    {
        public int Id { get; set; }
        public string Branch { get; set; }
        public string Company { get; set; }
        public string ProfitCenter { get; set; }
        public string CostCenter { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string VoucherNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string ProductCode { get; set; }
        public decimal? InwardQty { get; set; }
        public decimal? OutwardQty { get; set; }
        public decimal? Rate { get; set; }
        public string AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string EditWho { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

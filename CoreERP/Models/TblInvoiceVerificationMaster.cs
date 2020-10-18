using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInvoiceVerificationMaster
    {
        public string PurchaseOrderNo { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string Plant { get; set; }
        public string ProfitCenter { get; set; }
        public string SupplierCode { get; set; }
        public string Description { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public string InvoiceReferenceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Grnno { get; set; }
        public DateTime? Grndate { get; set; }
        public string AddWho { get; set; }
        public string EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

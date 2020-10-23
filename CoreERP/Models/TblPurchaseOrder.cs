using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseOrder
    {
        public string QuotationNumber { get; set; }
        public string Company { get; set; }
        public string Plant { get; set; }
        public string Branch { get; set; }
        public string ProfitCenter { get; set; }
        public string PurchaseOrderType { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public DateTime? QuotationDate { get; set; }
        public string SupplierCode { get; set; }
        public string Gstno { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? DeliveryPeriod { get; set; }
        public string TermsofDelivery { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        public string AddWho { get; set; }
        public string EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }
        public decimal? Advance { get; set; }
        public string FilePath { get; set; }
    }
}

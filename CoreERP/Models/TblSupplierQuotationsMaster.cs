using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblSupplierQuotationsMaster
    {
        public string? ID { get; set; }
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? QuotationNumber { get; set; }
        public DateTime? SupplierQuoteDate { get; set; }
        public string? CustomerCode { get; set; }
        public string? DeliveryPeriod { get; set; }
        public string? CreditDays { get; set; }
        public string? DeliveryMethod { get; set; }
        public decimal? Advance { get; set; }
        public string? TransportMethod { get; set; }
        public string? Branch { get; set; }
        public string? ProfitCenter { get; set; }
        public DateTime? QuotationDate { get; set; }
        public string? Status { get; set; }
        public string? SupplierName { get; set; }
        public string? CompanyName { get; set; }
        public string? ProfitcenterName { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Amount { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? IGST { get; set; }
        public decimal? UGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public string? Gstno { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EditDate { get; set; }
        public string? EditWho { get; set; }
        public string? RecomendedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public string? Material { get; set; }
        public string? SaleorderNo { get; set; }
        public string? RefNo { get; set; }
        public string? ResponsiblePerson { get; set; }
        public string? Quotationfor { get; set; }


    }
}

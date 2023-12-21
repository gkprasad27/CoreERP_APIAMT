using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_SaleOrderMaster")]
    public partial class TblSaleOrderMaster
    {
        public string? SaleOrderNo { get; set; }
        public string? CustomerCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public DateTime? DateofSupply { get; set; }
        public string? PlaceofSupply { get; set; }
        public string? DocumentURL { get; set; }
        public string? Status { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? IGST { get; set; }
        public decimal? UGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Company { get; set; }
        public string? SupplierName { get; set; }
        public string? ProfitcenterName { get; set; }
        public string? CompanyName { get; set; }
        public string? Gstno { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EditDate { get; set; }
        public string? EditWho { get; set; }
        public int TotalQty { get; set; }
        public string? RecomendedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? DispatchedDate { get; set; }

    }
}

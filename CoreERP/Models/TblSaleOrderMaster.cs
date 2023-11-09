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
        public string? ProfircenterName { get; set; }
        public string? CompanyName { get; set; }

    }
}

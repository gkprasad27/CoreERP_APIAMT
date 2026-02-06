using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("GSTUpload")]
    public partial class GSTUpload
    {
        public int ID { get; set; }
        public string GSTNumber { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceType { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceValue { get; set; }
        public string PlaceofSupply { get; set; }
        public int GSTRate { get; set; }
        public decimal TaxableValue { get; set; }
        public decimal IGST { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal Cess { get; set; }
        public string GSTRFillingStatus { get; set; }
        public DateTime GSTRFillingDate { get; set; }
        public DateTime GSTRFillingPeriod { get; set; }
        public string GSTR3BFillingStatus { get; set; }
        public string AmmendementMade { get; set; }
        public string AmendedTaxPeriod { get; set; }
        public DateTime CancellationDate { get; set; }
        public string Source { get; set; }
        public string IRN { get; set; }
        public DateTime IRNDate { get; set; }
        public string Ext1 { get; set; }
        public string Company { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EditDate { get; set; }
        public string EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AddDate { get; set; }
        public string AddWho { get; set; }
       
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBarcodeSettings
    {
        public decimal BarcodeSettingsId { get; set; }
        public bool? ShowProductCode { get; set; }
        public bool? ShowCompanyName { get; set; }
        public string CompanyName { get; set; }
        public bool? ShowPurchaseRate { get; set; }
        public bool? ShowMrp { get; set; }
        public string Point { get; set; }
        public string Zero { get; set; }
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
        public string Six { get; set; }
        public string Seven { get; set; }
        public string Eight { get; set; }
        public string Nine { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public DateTime? ExtraDate { get; set; }
    }
}

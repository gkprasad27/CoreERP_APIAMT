﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_JobworkMaster")]
    public partial class tblJobworkMaster
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? JobWorkNumber { get; set; }
        public string? Vendor { get; set; }
        public string Company { get; set; }
        public string? ProfitCenter { get; set; }
        public string? VendorGSTN { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }       
        public string? Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DocumentURL { get; set; }
        public string InvoiceURL { get; set; }
        public string CreatedBy { get; set; }
        public string ContactNo { get; set; }
        public string SaleOrderNo { get; set; }
        
    }
}

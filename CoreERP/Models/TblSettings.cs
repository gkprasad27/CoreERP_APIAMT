using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSettings
    {
        public decimal SettingsId { get; set; }
        public string SettingsName { get; set; }
        public string Status { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

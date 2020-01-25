using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class PartnerType
    {
        public string Code { get; set; }
        public string AccountType { get; set; }
        public string Description { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

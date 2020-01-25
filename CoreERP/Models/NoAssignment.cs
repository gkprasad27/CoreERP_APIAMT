using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class NoAssignment
    {
        public string Code { get; set; }
        public string CompanyCode { get; set; }
        public string Description { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string MaterialGroup { get; set; }
        public string NoType { get; set; }
        public string NumberInterval { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

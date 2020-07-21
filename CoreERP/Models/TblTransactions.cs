using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTransactions
    {
        public int Id { get; set; }
        public string TaxTransCode { get; set; }
        public string Description { get; set; }
        public string Ext { get; set; }
        public string Ext1 { get; set; }
    }
}

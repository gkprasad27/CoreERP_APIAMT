using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTaxtypes
    {
        public int Id { get; set; }
        public string TaxKey { get; set; }
        public string Description { get; set; }
        public string Ext { get; set; }
        public string Ext1 { get; set; }
    }
}

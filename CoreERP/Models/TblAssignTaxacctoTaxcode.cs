using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignTaxacctoTaxcode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? Sgstgl { get; set; }
        public decimal? Cgstgl { get; set; }
        public decimal? Igstgl { get; set; }
        public decimal? Ugstgl { get; set; }
        public string Description { get; set; }
        public string Ext { get; set; }
    }
}

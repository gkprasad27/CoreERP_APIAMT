using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignTaxacctoTaxcode
    {
        public string? Code { get; set; }
        public string? Sgstgl { get; set; }
        public string? Cgstgl { get; set; }
        public string? Igstgl { get; set; }
        public string? Ugstgl { get; set; }
        public string? Company { get; set; }
        public string? Branch { get; set; }
        public string? Plant { get; set; }
        public string? CompositeAccount { get; set; }
        public string? ChartofAccount { get; set; }
    }
}

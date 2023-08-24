using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAlternateControlAccTrans
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? NormalControlAccount { get; set; }
        public string? AlternativeControlAccount { get; set; }
        public string? ChartofAccount { get; set; }
        public string? Company { get; set; }
    }
}

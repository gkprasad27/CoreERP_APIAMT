using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblGinseriesAssignment
    {

        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? Ginseries { get; set; }
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? MaterilaType { get; set; }
        public int? CurrentNumber { get; set; }
    }
}

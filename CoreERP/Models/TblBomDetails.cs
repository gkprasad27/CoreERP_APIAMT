using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBomDetails
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? BomKey { get; set; }
        public string? BomLevel { get; set; }
        public string? Component { get; set; }
        public string? Description { get; set; }
        public string? ManufacturingType { get; set; }
        public string? Type { get; set; }
        public string? AboveLevel { get; set; }
        public int? Qty { get; set; }
        public string? Uom { get; set; }
    }
}

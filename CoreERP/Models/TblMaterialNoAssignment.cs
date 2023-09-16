using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialNoAssignment
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public string? NumberRange { get; set; }
        public string? CompanyCode { get; set; }
        public string? Plant { get; set; }
        public string? MaterialType { get; set; }
    }
}

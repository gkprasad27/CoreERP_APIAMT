using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("StructureCreation")]
    public partial class StructureCreation
    {
        public string StructureCode { get; set; }
        public string? StructureName { get; set; }
        public string? CompanyCode { get; set; }
        public string? Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_Dispatch")]
    public partial class TblQCParamConfig
    {
        public int ID { get; set; }
        public string? ParamName { get; set; }
        public string? Type { get; set; }
        public int? SortOrder { get; set; }
        public string? Product { get;set; }
    }
}

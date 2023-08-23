using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetBegningAccumulatedDepreciation
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Code { get; set; }
        public string? mainAssetNo { get; set; }
        public string? AccumulatedDepreciation { get; set; }
        public string? subAssetNo { get; set; }
        public string? DepreciationArea { get; set; }
    }
}

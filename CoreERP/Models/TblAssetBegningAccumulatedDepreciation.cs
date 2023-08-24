using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetBegningAccumulatedDepreciation
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? mainAssetNo { get; set; }
        public string? accumulatedDepreciation { get; set; }
        public string? subAssetNo { get; set; }
        public string? depreciationArea { get; set; }
    }
}

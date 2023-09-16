using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetBeginingAcquisitionDetail
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? Code { get; set; }
        public string? DepreciationArea { get; set; }
        public string? AccumulatedDepreciation { get; set; }
    }
}

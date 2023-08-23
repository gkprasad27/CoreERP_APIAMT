using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetBeginingAcquisition
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Code { get; set; }
        public string? MainAssetNo { get; set; }
        public string? MainAssetDescription { get; set; }
        public string? SubAssetNo { get; set; }
        public string? SubAssetDescription { get; set; }
        public string? DepreciationArea { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public decimal? AcquisitionCost { get; set; }
    }
}

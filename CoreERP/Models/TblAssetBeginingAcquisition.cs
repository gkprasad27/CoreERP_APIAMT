using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetBeginingAcquisition
    {
        public int Id { get; set; }
        public string MainAssetNo { get; set; }
        public string MainAssetDescription { get; set; }
        public string SubAssetNo { get; set; }
        public string SubAssetDescription { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public decimal? AcquisitionCost { get; set; }
    }
}

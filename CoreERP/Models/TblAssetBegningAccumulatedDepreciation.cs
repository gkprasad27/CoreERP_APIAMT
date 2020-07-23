using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetBegningAccumulatedDepreciation
    {
        public int Id { get; set; }
        public string MainAssetNo { get; set; }
        public string SubAssetNo { get; set; }
        public string DepreciationArea { get; set; }
        public string AccumulatedDepreciation { get; set; }
    }
}

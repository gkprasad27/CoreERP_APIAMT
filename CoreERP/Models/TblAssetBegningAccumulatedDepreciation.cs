using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetBegningAccumulatedDepreciation
    {
        public int Id { get; set; }
        public string AcquisitionCode { get; set; }
        public string DepreciationArea { get; set; }
        public string AccumulatedDepreciation { get; set; }
    }
}

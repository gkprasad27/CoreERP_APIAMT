using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetBlock
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DepreciationKey { get; set; }
        public string Ext { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSubAssetMaster
    {
        public int Id { get; set; }
        public string SubAssetNumber { get; set; }
        public string MainAssetNo { get; set; }
        public string Description { get; set; }
        public string Ext { get; set; }
    }
}

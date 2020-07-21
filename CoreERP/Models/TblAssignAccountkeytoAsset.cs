using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignAccountkeytoAsset
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string AssetClass { get; set; }
        public string AccountKey { get; set; }
        public string Description { get; set; }
    }
}

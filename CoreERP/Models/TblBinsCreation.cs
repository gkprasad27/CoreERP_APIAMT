using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBinsCreation
    {
        public string? BinNumber { get; set; }
        public string? Description { get; set; }
        public string? Plant { get; set; }
        public string? StorageLocation { get; set; }
        public string? Material { get; set; }
        public int? MinLevel { get; set; }
        public int? MaxLevel { get; set; }
        public int? ReOrderLevel { get; set; }
        public int? OpenQty { get; set; }
        public int? Uom { get; set; }
        public string? StoreIncharge { get; set; }
    }
}

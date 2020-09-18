using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCostingUnitsCreation
    {
        public string ObjectType { get; set; }
        public string ObjectNumber { get; set; }
        public string Description { get; set; }
        public string CostUnitType { get; set; }
        public string PerUnitCostBy { get; set; }
        public string ManufacturingType { get; set; }
        public string Material { get; set; }
    }
}

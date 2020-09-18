using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRoutingMaterialAssignment
    {
        public int Id { get; set; }
        public string RoutingKey { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public int? Qty { get; set; }
        public string Uom { get; set; }
    }
}

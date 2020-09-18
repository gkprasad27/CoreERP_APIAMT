using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRoutingMasterData
    {
        public string Company { get; set; }
        public string Plant { get; set; }
        public string CostUnit { get; set; }
        public string Material { get; set; }
        public string OrderNumber { get; set; }
        public string SaleOrder { get; set; }
        public string SaleDocument { get; set; }
        public string RoutingKey { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Version { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRoutingActiitiesAssignment
    {
        public int Id { get; set; }
        public string RoutingKey { get; set; }
        public string WorkCenter { get; set; }
        public string CostCenter { get; set; }
        public string Activity { get; set; }
        public string StandardValue { get; set; }
        public string Uom { get; set; }
        public string Formula { get; set; }
    }
}

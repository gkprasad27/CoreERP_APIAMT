using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRoutingBasicData
    {
        public int Id { get; set; }
        public string RoutingKey { get; set; }
        public string Operation { get; set; }
        public string SubOperation { get; set; }
        public string WorkCenter { get; set; }
        public int? BaseQuantity { get; set; }
        public string OperationUnit { get; set; }
    }
}

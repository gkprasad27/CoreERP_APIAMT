using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRoutingToolsEqupments
    {
        public int Id { get; set; }
        public string? RoutingKey { get; set; }
        public string? ToolsEqupment { get; set; }
        public string? Description { get; set; }
        public int? Numbers { get; set; }
    }
}

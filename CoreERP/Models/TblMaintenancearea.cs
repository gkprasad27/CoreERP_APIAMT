using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaintenancearea
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Plant { get; set; }
        public string Ext { get; set; }
    }
}

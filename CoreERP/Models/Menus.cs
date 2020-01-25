using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Menus
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public int? MenuOrder { get; set; }
        public string ParentId { get; set; }
        public string DisplayName { get; set; }
        public string Active { get; set; }
        public string IsMasterScreen { get; set; }
        public string Route { get; set; }
        public string IconName { get; set; }
        public string Ext1 { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

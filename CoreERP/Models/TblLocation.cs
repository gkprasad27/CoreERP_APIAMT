using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblLocation
    {
        public int Id { get; set; }
        public string LocationId { get; set; }
        public string Description { get; set; }
        public string Plant { get; set; }
        public string Ext { get; set; }
    }
}

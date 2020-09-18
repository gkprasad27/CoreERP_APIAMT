using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TbBommaster
    {
        public string Company { get; set; }
        public string Plant { get; set; }
        public string Bomtype { get; set; }
        public string Bomnumber { get; set; }
        public string Description { get; set; }
        public string CostUnit { get; set; }
        public string Material { get; set; }
        public string Batch { get; set; }
        public string CreatedBy { get; set; }
        public string LevelType { get; set; }
    }
}

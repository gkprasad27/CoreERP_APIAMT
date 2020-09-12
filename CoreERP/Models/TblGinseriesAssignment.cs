using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblGinseriesAssignment
    {
        public string Ginseries { get; set; }
        public string Company { get; set; }
        public string Plant { get; set; }
        public string MaterilaType { get; set; }
        public int? CurrentNumber { get; set; }
    }
}

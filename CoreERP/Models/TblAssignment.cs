using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignment
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Desctiption { get; set; }
        public string Bpgroup { get; set; }
        public string NumberRangeKey { get; set; }
    }
}

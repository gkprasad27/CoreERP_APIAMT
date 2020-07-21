using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBpgroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Bptype { get; set; }
        public string Description { get; set; }
        public string Ext1 { get; set; }
    }
}

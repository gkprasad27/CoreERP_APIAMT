using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialTypes
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        public string Usage { get; set; }
        public int? Ext1 { get; set; }
    }
}

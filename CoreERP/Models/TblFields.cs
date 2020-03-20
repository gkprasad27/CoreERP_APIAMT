using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblFields
    {
        public int FieldId { get; set; }
        public int? FormId { get; set; }
        public string FieldName { get; set; }
    }
}

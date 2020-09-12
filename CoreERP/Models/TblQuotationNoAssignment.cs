using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblQuotationNoAssignment
    {
        public string NumberRange { get; set; }
        public string Company { get; set; }
        public string Plant { get; set; }
        public int? CurrentNumber { get; set; }
    }
}

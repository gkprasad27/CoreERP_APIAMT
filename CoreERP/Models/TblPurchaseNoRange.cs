using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseNoRange
    {
        public string NumberRange { get; set; }
        public int? FromInterval { get; set; }
        public int? ToInterval { get; set; }
        public int? CurrentNumber { get; set; }
        public string Prefix { get; set; }
    }
}

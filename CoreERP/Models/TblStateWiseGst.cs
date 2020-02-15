using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblStateWiseGst
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public int Cgst { get; set; }
        public int Sgst { get; set; }
        public int Igst { get; set; }
        public int IsDefault { get; set; }

        public virtual States State { get; set; }
    }
}

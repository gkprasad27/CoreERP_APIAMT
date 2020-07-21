using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblNumberAssignment
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Bpgroup { get; set; }
        public string NumberRange { get; set; }
    }
}

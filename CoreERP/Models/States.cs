using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class States
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual Countries Country { get; set; }
        public virtual TblStateWiseGst TblStateWiseGst { get; set; }
    }
}

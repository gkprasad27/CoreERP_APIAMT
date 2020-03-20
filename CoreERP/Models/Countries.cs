using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Countries
    {
        public Countries()
        {
            States = new HashSet<States>();
        }

        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<States> States { get; set; }
    }
}

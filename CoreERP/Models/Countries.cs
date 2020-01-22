using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Countries
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Active { get; set; }
    }
}

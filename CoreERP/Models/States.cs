using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class States
    {
        public int Id { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}

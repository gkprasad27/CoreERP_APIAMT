using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class ConfigurationTable
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string ConfigurationType { get; set; }
        public string Active { get; set; }
    }
}

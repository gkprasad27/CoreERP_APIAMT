using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class ErpConfiguration
    {
        public string Module { get; set; }
        public string Screen { get; set; }
        public string KeyName { get; set; }
        public string Values { get; set; }
        public int SequenceId { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

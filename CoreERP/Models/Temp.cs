using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Temp
    {
        public decimal? AccountGroupId { get; set; }
        public string AccountGroupName { get; set; }
        public decimal? GroupUnder { get; set; }
    }
}

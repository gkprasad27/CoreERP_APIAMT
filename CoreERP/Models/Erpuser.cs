using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Erpuser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

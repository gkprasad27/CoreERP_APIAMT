using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblUserTest
    {
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
        public decimal? RoleId { get; set; }
        public string FullName { get; set; }
    }
}

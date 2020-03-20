using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRolePrivilegeMenu
    {
        public decimal Id { get; set; }
        public decimal? MenuId { get; set; }
        public decimal? RoleId { get; set; }
    }
}

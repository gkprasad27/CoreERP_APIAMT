using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRolePrivilegeForm
    {
        public decimal PrivilegeId { get; set; }
        public decimal? MainMenuId { get; set; }
        public bool? IsMenuActive { get; set; }
        public decimal? FormId { get; set; }
        public string FormName { get; set; }
        public decimal? RoleId { get; set; }
        public string Role { get; set; }
        public bool? IsFormActive { get; set; }
        public bool? Add { get; set; }
        public bool? View { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
    }
}

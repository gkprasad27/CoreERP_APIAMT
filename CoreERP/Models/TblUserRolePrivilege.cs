using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblUserRolePrivilege
    {
        public decimal PrivilegeId { get; set; }
        public decimal? FormId { get; set; }
        public string FormName { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public decimal? UserId { get; set; }
        public decimal? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal? RoleId { get; set; }
        public string Role { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsMenuActive { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool? Add { get; set; }
        public bool? View { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
    }
}

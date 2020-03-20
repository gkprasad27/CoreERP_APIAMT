using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPrivilege
    {
        public decimal PrivilegeId { get; set; }
        public string FormName { get; set; }
        public string Action { get; set; }
        public decimal? RoleId { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Exatra1 { get; set; }
        public string Extra2 { get; set; }
    }
}

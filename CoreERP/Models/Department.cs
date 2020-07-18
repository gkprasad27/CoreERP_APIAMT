using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string ResponsiblePersonCode { get; set; }
        public bool? IsActive { get; set; }
        public string Ext1 { get; set; }
    }
}

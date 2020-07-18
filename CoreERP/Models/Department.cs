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
        public string ResponsiblePersonDesc { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyDesc { get; set; }
        public string CompanyGroupCode { get; set; }
    }
}

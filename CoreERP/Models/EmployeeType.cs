using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class EmployeeType
    {
        public string EmployeeId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyDesc { get; set; }
        public string CompanyGroupCode { get; set; }
        public string EmployeeName { get; set; }
        public string Active { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class PayrollCycle
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeGroupId { get; set; }
        public string EmployeeGroupName { get; set; }
        public string ProfitCenterCode { get; set; }
        public string ProfitCenterName { get; set; }
        public DateTime? CycleDate { get; set; }
        public string CycleName { get; set; }
        public string DesignationCode { get; set; }
        public string DesignationName { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public string Active { get; set; }
    }
}

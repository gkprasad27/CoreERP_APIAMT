using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class PayrollCycle
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string DepartmentCode { get; set; }
        public string EmployeeGroupId { get; set; }
        public string CycleDate { get; set; }
        public string CycleName { get; set; }
        public string Active { get; set; }
        public DateTime? EffectiedDate { get; set; }
        public string EditWho { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

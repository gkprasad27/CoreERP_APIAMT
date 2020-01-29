using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class ComponentMaster
    {
        public string ComponentCode { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
        public string Remarks { get; set; }
        public string CompanyCode { get; set; }
        public double? Amount { get; set; }
        public int? Percentage { get; set; }
        public string Duration { get; set; }
        public string SpecificMonth { get; set; }
        public string Active { get; set; }
    }
}

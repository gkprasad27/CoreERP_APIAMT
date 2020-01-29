using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class StructureCreation
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string ProfitCenter { get; set; }
        public string Branch { get; set; }
        public string Department { get; set; }
        public string ComponentCode { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
        public string Remarks { get; set; }
        public string CompanyName { get; set; }
        public double? Amount { get; set; }
        public double? Percentage { get; set; }
        public string StructureName { get; set; }
        public string AmountType { get; set; }
        public string Active { get; set; }
    }
}

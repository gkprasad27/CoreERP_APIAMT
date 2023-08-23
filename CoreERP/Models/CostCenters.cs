using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class CostCenters
    {
        public string? Code { get; set; }
        public string? CompCode { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? objectType { get; set; }
        public string? functions { get; set; }
        public string? Place { get; set; }
        public string? State { get; set; }
        public string? PinCode { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? CostObject { get; set; }
        public string? Email { get; set; }
        public string? ResponsiblePerson { get; set; }
        public string? Active { get; set; }
        public DateTime? AddDate { get; set; }
        public string? Department { get; set; }
        public DateTime? FromDate { get; set; }
        public string? Location { get; set; }
        public string? Quality { get; set; }
        public string? Type { get; set; }
    }
}

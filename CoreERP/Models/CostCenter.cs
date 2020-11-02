using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class CostCenter
    {
        public string ObjectType { get; set; }
        public string Code { get; set; }
        public string CostCenterName { get; set; }
        public string Functions { get; set; }
        public string Type { get; set; }
        public string Quantity { get; set; }
        public string Department { get; set; }
        public int? Uom { get; set; }
        public string ResponsiblePerson { get; set; }
        public DateTime? FromDate { get; set; }
        public string CostType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

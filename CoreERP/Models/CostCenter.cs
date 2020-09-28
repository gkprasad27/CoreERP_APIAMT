using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class CostCenter
    {
        public string ObjectType { get; set; }
        public int? Number { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Functions { get; set; }
        public string Type { get; set; }
        public string Quantity { get; set; }
        public string Department { get; set; }
        public string Uom { get; set; }
        public string ResponsiblePerson { get; set; }
        public DateTime? FromDate { get; set; }
        public string CostType { get; set; }
    }
}

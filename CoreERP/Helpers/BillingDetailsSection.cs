using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Helpers
{
    public class BillingDetailsSection
    {
        public string productCode { get; set; }
        public string productName { get; set; }
        public string hsnCode { get; set; }
        public decimal? qty { get; set; }
        public decimal? fqty { get; set; }
        public decimal? UnitId { get; set; }
        public string UnitName { get; set; }
        public string taxcode { get; set; }
        public decimal? Rate { get; set; }
    }
}

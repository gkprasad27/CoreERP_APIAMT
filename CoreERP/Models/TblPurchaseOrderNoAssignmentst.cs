using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseOrderNoAssignmentst
    {
        public string NumberRange { get; set; }
        public string CompanyCode { get; set; }
        public string Plant { get; set; }
        public string PurchaseOrderType { get; set; }
        public int? CurrentNumber { get; set; }
    }
}

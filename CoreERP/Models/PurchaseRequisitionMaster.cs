using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class PurchaseRequisitionMaster
    {
        public string Company { get; set; }
        public string Branch { get; set; }
        public string RequisitionNo { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public int Id { get; set; }
        public string Status { get; set; }
    }
}

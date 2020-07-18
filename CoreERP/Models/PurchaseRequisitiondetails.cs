using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class PurchaseRequisitiondetails
    {
        public decimal RequisitionDetailId { get; set; }
        public decimal? ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal AvailbleQtyinBranch { get; set; }
        public decimal? AvailbleQtyinGowdown { get; set; }
        public string ApprovedQty { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Purchasereqisitionid { get; set; }
        public string Status { get; set; }
    }
}

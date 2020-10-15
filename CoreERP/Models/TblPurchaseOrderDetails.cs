using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseOrderDetails
    {
        public int Id { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public int? Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public string ProfitCenter { get; set; }
        public string Branch { get; set; }
        public string CostCenter { get; set; }
        public string Wbs { get; set; }
        public string FundCenter { get; set; }
        public string Commitment { get; set; }
        public string Plant { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string PreparedBy { get; set; }
        public string RecommendedBy { get; set; }
        public string ApprovedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialMaster
    {
        public string Company { get; set; }
        public string Plant { get; set; }
        public string MaterialType { get; set; }
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public string MaterialGroup { get; set; }
        public string Size { get; set; }
        public string ModelPattern { get; set; }
        public string Uom { get; set; }
        public string Division { get; set; }
        public decimal? GrossWeight { get; set; }
        public string Ouom { get; set; }
        public decimal? NetWeight { get; set; }
        public string PurchasingGroup { get; set; }
        public string PurchaseOrderText { get; set; }
        public int? MinLevel { get; set; }
        public int? MaxLevel { get; set; }
        public int? ReOrderLevel { get; set; }
        public int? DangerLevel { get; set; }
        public int? EconomicOrderQty { get; set; }
        public int? ReorderPoint { get; set; }
        public string Valuation { get; set; }
        public int? OpeningQty { get; set; }
        public int? ClosingQty { get; set; }
        public string Qtyvalues { get; set; }
        public decimal? TransferPrice { get; set; }
        public string Hsnsac { get; set; }
        public string Classification { get; set; }
        public string Taxable { get; set; }
        public string Schedule { get; set; }
        public string Chapter { get; set; }
        public string GoodsServiceDescription { get; set; }
        public string EditWho { get; set; }
        public string AddWho { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? AddDate { get; set; }
        public string NetWeightUom { get; set; }
        public int? OpeningPrice { get; set; }
        public int? OpeningValue { get; set; }
        public int? ClosingPrice { get; set; }
        public int? ClosingValue { get; set; }
    }
}

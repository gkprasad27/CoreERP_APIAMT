using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialRequisitionDetails
    {
        public int Id { get; set; }
        public string RequisitionNumber { get; set; }
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public int? Qty { get; set; }
        public string SotrageLocation { get; set; }
        public string JoborProject { get; set; }
        public string CostCenter { get; set; }
        public string ProfitCenter { get; set; }
        public string Wbs { get; set; }
        public string Order { get; set; }
        public decimal? Price { get; set; }
        public decimal? Value { get; set; }
    }
}

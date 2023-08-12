using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssetAccountkey
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? AcquisitionsGl { get; set; }
        public string? AccumulatedGl { get; set; }
        public string? DepreciationGl { get; set; }
        public string? SalesRevenueGl { get; set; }
        public string? LossOnSaleGl { get; set; }
        public string? GainOnSaleGl { get; set; }
        public string? ScrappingGl { get; set; }
        public string? Auggl { get; set; }
        public string? CompanyCode { get; set; }
        public string? ChartofAccount { get; set; }
    }
}

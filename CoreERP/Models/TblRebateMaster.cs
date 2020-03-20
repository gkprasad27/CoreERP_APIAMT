using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRebateMaster
    {
        public decimal RebateMasterId { get; set; }
        public decimal RebateId { get; set; }
        public string RebateName { get; set; }
        public decimal MemberCretiria { get; set; }
        public decimal? DieselQty { get; set; }
        public decimal? RebatePerLtr { get; set; }
        public decimal? SparesPercentage { get; set; }
        public decimal? FineAmount { get; set; }
        public int IsActive { get; set; }

        public virtual TblRebateType Rebate { get; set; }
    }
}

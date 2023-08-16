using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblInpectionCheckMaster
    {
        public string? InspectionCheckNo { get; set; }
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? Branch { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Status { get; set; }
        public string? AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

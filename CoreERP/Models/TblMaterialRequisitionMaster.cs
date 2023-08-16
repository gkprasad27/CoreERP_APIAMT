using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialRequisitionMaster
    {
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? Branch { get; set; }
        public string? Department { get; set; }
        public string? Project { get; set; }
        public string? BomorderNumber { get; set; }
        public string? RequisitionNmber { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public string? AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string? EditWho { get; set; }
        public string? Status { get; set; }
    }
}

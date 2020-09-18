using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPurchaseRequisitionMaster
    {
        public string Company { get; set; }
        public string Plant { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        public string CostCenter { get; set; }
        public string ProfitCenter { get; set; }
        public string Wbs { get; set; }
        public string ProjectName { get; set; }
        public string Requiredfor { get; set; }
        public string RequisitionNumber { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public string Narration { get; set; }
        public string AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string EditWho { get; set; }
        public DateTime? EditDate { get; set; }
        public string RecomendedBy { get; set; }
        public DateTime? RecomendedDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Status { get; set; }
    }
}

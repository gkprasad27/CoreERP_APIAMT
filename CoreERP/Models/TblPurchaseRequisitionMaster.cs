using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblPurchaseRequisitionMaster
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? Company { get; set; }
        public string? Plant { get; set; }
        public string? Department { get; set; }
        public string? Branch { get; set; }
        public string? CostCenter { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Wbs { get; set; }
        public string? ProjectName { get; set; }
        public string? Requiredfor { get; set; }
        public string? RequisitionNumber { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public string? Narration { get; set; }
        public string? AddWho { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public string? RecomendedBy { get; set; }
        public DateTime? RecomendedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Status { get; set; }
        public string? DepartmentName { get; set; }
        public string? ProfitcenterName { get; set; }
        public string? CompanyName { get; set; }
        public int TotalQty { get; set; }

    }
}

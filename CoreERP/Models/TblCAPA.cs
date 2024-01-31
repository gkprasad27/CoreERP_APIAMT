using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_CAPA")]
    public partial class TblCAPA
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DeadlineMonitorDate { get; set; }
        public DateTime? ReceivedPartsDate { get; set; }
        public DateTime? analysisBugunDate { get; set; }
        public DateTime? DefectCauseAcknowledgeDate { get; set; }
        public DateTime? ShortTermSolDate { get; set; }
        public DateTime? longTermSolDate { get; set; }
        public DateTime? ContainmentReqdDate { get; set; }
        public DateTime? SolutionInspectedDate { get; set; }
        public string? NotificationNo { get; set; }
        public string? ItemCode { get; set; }
        public string? DefectCause { get; set; }
        public string MaterialDescription { get; set; }
        public DateTime? NotificationDate { get; set; }
        public int? ComplaintQty { get; set; }
        public string? Tag { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }

        public string? DecfectDescription { get; set; }
        public string? DefectCasuseResp { get; set; }
        public string? ShortTermSolution { get; set; }
        public string? ShortTermSolutionResp { get; set; }
        public DateTime? ShortTermSolutionDate { get; set; }
        public string? LongTermSolution { get; set; }
        public string? LongTermSolutionResp { get; set; }
        public DateTime? LongTermSolutionDate { get; set; }
        public string? IdentificationOfDelvrdMaterial { get; set; }
        public string? IdentificationOfDelvrdMaterialResp { get; set; }
        public DateTime? IdentificationOfDelvrdMaterialDate { get; set; }
        public string? CheckSuccessDelrdMaterail { get; set; }
        public string? CheckSuccessDelrdMaterailResp { get; set; }
        public DateTime? CheckSuccessDelrdMaterailDate { get; set; }
        public string? ContainmentAccess { get; set; }
        public string? ContainmentAccessResp { get; set; }
        public DateTime? ContainmentAccessDate { get; set; }
        public string? CustVerification { get; set; }
        public DateTime? CustVerificationDate { get; set; }
        public string? CAPANUM { get; set; }
        public DateTime? DefectCasuseDate { get; set; }
        public string? SaleOrderNo { get; set; }
        public string? Status { get; set; }
        public string? CustmerPO { get; set; }
        public string? CustomerCode { get; set; }

    }
}

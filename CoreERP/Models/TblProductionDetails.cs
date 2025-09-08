using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_productiondetails")]
    public partial class TblProductionDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? SaleOrderNumber { get; set; }
        public string? ProductionTag { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? AllocatedPerson { get; set; }
        public string? TypeofWork { get; set; }
        public string? Remarks  { get; set; }
        public decimal Duration { get; set; }
        public string MaterialCode { get; set; }
        public bool IsReject { get; set; }
        public string WorkStatus { get; set; }    
        public string Mechine { get; set; }
        public string MaterialName { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public DateTime? ProductionPlanDate { get; set; }
        public DateTime? ProductionTargetDate { get; set; }
        public string? BomKey { get; set; }
        public string? BomName { get; set; }
        public string? Company { get; set; }
        public string? ApprovalStatus { get; set; }
        public string? LotNo { get; set; }
    }
}

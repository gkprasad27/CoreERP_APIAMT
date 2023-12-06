using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class tblQCMaster
    {
        public string Code { get; set; }       
        public string? Type { get; set; }
        public bool? IsActive { get; set; }
        public string? MaterialCode { get; set; }
        public string? TagName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EditDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AddDate { get; set; }
        public string? AddWho { get; set; }
        public string? InspectionType { get; set; }
        public string? HeatNumber { get; set; }
        public string? PartDrgNo { get; set; }
    }
}

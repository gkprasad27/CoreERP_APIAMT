using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_Offer")]
    public partial class TblOffer
    {
        public int ID { get; set; }
        public string EmpCode { get; set; }
        public string? Role { get; set; }
        public string? JobType { get; set; }
        public string? Reporting { get; set; }
        public string? EmpName { get; set; }
        public string? Designation { get; set; }
        public decimal? CTC { get; set; }
        public DateTime? OfferValid { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }

    }
}

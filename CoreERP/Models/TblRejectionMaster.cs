﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_RejectionMaster")]
    public partial class TblRejectionMaster
    {
        public int ID { get; set; }
        public string? SaleOrderNo { get; set; }
        public string? MaterialCode { get; set; }
        public string TagNo { get; set; }
        public string? Reason { get; set; }
        public string? RejectdPerson { get; set; }
        public string? ApprovedPerson { get; set; }
        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
        public string? Status { get; set; }
    }


}

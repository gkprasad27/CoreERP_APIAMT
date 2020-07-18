using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblGiftMaster
    {
        public string MemberCode { get; set; }
        public string GiftId { get; set; }
        public bool? Status { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Description { get; set; }
        public string EditWho { get; set; }
        public string AddWho { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? AddDate { get; set; }
        public int Year { get; set; }
        public string GiftName { get; set; }
    }
}

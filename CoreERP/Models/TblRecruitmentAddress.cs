using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblRecruitmentAddress
    {
        public int ID { get; set; }
        public string? EmpCode { get; set; }
        public string? PAddress1 { get; set; }
        public string? PAddress { get; set; }
        public string? PCity { get; set; }
        public string? PState { get; set; }
        public string? PZip { get; set; }
        public string? PLocation { get; set; }
        public string? PCountry { get; set; }
        public string? Address { get; set; }
        public string? Address1 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; }
        public string? AddWho { get; set; }
        public string? EditWho { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EditDate { get; set; }

    }
}

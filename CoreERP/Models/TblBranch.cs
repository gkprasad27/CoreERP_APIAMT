using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBranch
    {
        public decimal BranchId { get; set; }
        public decimal? CompanyId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int? IsMainBranch { get; set; }
        public decimal? SubBranchof { get; set; }
        public byte[] BranchImage { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Gstin { get; set; }
        public string Narration { get; set; }
        public string SapCode { get; set; }
    }
}

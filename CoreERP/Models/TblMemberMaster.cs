using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMemberMaster
    {
        public decimal MemberId { get; set; }
        public decimal? MemberCode { get; set; }
        public string Title { get; set; }
        public string MemberName { get; set; }
        public string FatherOrHusbandName { get; set; }
        public int? MemberAge { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string GovtIdentityType { get; set; }
        public string GovtIdentity { get; set; }
        public string Occupation { get; set; }
        public string Nominee { get; set; }
        public string Relation { get; set; }
        public DateTime? PassBook { get; set; }
        public string PassBookStatus { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? NoofShares { get; set; }
        public int? IssuedShares { get; set; }
        public int? ReceivedShares { get; set; }
        public int? TotalShares { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int IsActive { get; set; }
        public string AadharNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string GiftIssued { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? GiftIssuedDate { get; set; }
    }
}

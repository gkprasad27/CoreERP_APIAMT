using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class PartnerDetails
    {
        public string PartnerCode { get; set; }
        public string PartnerName { get; set; }
        public string FatherOrhusbandName { get; set; }
        public int? MemberAge { get; set; }
        public string Gender { get; set; }
        public string GovtIdcardType { get; set; }
        public string IdcareNumber { get; set; }
        public string Occupation { get; set; }
        public string Nominee { get; set; }
        public string Relation { get; set; }
        public string Passbook { get; set; }
        public string PassbookStatus { get; set; }
        public int? NoOfShares { get; set; }
        public string Avtive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TourAdvance
    {
        public string EmpCode { get; set; }
        public DateTime ApplyDate { get; set; }
        public string PlaceOfVisiting { get; set; }
        public string Purpose { get; set; }
        public DateTime JourneyDate { get; set; }
        public DateTime? Jtime { get; set; }
        public double? ReqAmount { get; set; }
        public byte? NoOfDays { get; set; }
        public string Remarks { get; set; }
        public string AuthorisedStatus { get; set; }
        public string AuthorisedBy { get; set; }
        public DateTime? AuthorisedDate { get; set; }
        public string AuthorisedRemarks { get; set; }
        public string ApprovedStatus { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedRemarks { get; set; }
        public string AcceptedStatus { get; set; }
        public string AcceptedBy { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public double? AcceptedAmount { get; set; }
        public string AcceptedRemarks { get; set; }
        public string Skip { get; set; }
        public string ModeOfTransport { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}

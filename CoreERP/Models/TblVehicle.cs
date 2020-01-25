using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVehicle
    {
        public decimal VehicleId { get; set; }
        public decimal? MemberId { get; set; }
        public decimal? MemberCode { get; set; }
        public int? MemberShares { get; set; }
        public string VehicleRegNo { get; set; }
        public string VehicleModel { get; set; }
        public int? IsValid { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

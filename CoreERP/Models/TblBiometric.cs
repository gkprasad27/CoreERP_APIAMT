using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBiometric
    {
        public int Id { get; set; }
        public decimal EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? AttendanceDateTime { get; set; }
        public string InOutMode { get; set; }
        public decimal? WorkCode { get; set; }
        public string DeviceId { get; set; }
        public decimal? AttendanceId { get; set; }
        public DateTime? SyncDateTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CreatedBy { get; set; }
    }
}

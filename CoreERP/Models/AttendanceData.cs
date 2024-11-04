using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("AttendanceData")]
    public partial class AttendanceData
    {
        public int ID { get; set; }
        public string? EmpCode { get; set; }
        public DateTime? DateTimeStamp { get; set; }
        public string? InAndOut { get; set; }
        public string? DeviceAddress { get; set; }
        public string? TerminalId { get; set; }
        public string? PullStatus { get; set; }
        public string? StaffId { get; set; }
        public DateTime? LogDatetime { get; set; }
    }
}

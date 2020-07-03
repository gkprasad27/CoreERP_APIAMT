using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class AttendanceData
    {
        public long Id { get; set; }
        public string EmpCode { get; set; }
        public string EmployeeName { get; set; }
        public string Ouname { get; set; }
        public DateTime? DateTimeStamp { get; set; }
        public string InAndOut { get; set; }
        public string DeviceAddress { get; set; }
        public string TerminalId { get; set; }
        public string PullStatus { get; set; }
    }
}

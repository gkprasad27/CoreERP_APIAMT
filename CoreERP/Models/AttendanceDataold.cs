using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class AttendanceDataold
    {
        public string EmpCode { get; set; }
        public DateTime? DateTimeStamp { get; set; }
        public string InAndOut { get; set; }
        public string TerminalId { get; set; }
        public string PullStatus { get; set; }
    }
}

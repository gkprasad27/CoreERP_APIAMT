using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class LeaveTypes
    {
        public int Id { get; set; }
        public string LeaveCode { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string LeaveMinLimit { get; set; }
        public string LeaveMaxLimit { get; set; }
        public string LeaveName { get; set; }
        
    }
}

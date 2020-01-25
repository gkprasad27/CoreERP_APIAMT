using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class LeaveTypes
    {
        public string LeaveCode { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int? Id { get; set; }
        public string LeaveMaxLimit { get; set; }
        public string LeaveName { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

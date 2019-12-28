using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class ShiftTimeConfig
    {
        public string Code { get; set; }
        public string Branch { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyDesc { get; set; }
        public bool ConsiderNextday { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string DivCode { get; set; }
        public string DivisionName { get; set; }
        public DateTime? EffectFrom { get; set; }
        public string FirstInTime { get; set; }
        public string FirstOutTime { get; set; }
        public string InGracePeriod { get; set; }
        public string Name { get; set; }
        public string Userid { get; set; }
        public string Active { get; set; }
    }
}

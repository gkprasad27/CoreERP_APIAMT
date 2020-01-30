using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class SalaryEarnDedn
    {
        public string SalMonth { get; set; }
        public string SalYear { get; set; }
        public string EmpCode { get; set; }
        public string EarnDednCode { get; set; }
        public decimal? EarnDednAmount { get; set; }
        public decimal? ArrearsAmount { get; set; }
        public string Usrid { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string CompanyCode { get; set; }
        public string EmpGrp { get; set; }
        public string EmpGrpId { get; set; }
        public string ProfitCenterCode { get; set; }
        public string Active { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
    }
}

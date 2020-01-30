using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class MonthlyLeavesAvailed
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string EmployeeGroupId { get; set; }
        public string EmployeeGroupName { get; set; }
        public string LopMonth { get; set; }
        public string LopYear { get; set; }
        public double? OpnCl { get; set; }
        public double? OpnSl { get; set; }
        public double? OpnEl { get; set; }
        public double? Ph { get; set; }
        public double? Cl { get; set; }
        public double? Sl { get; set; }
        public double? El { get; set; }
        public double? Co { get; set; }
        public double? Wo { get; set; }
        public double? Ssl { get; set; }
        public double? Lop { get; set; }
        public double? PaidDays { get; set; }
        public double? ExtraDays { get; set; }
        public double? Othrs { get; set; }
        public int? Ot4hrs { get; set; }
        public int? Ot8hrs { get; set; }
        public string MonthYear { get; set; }
        public string Remarks { get; set; }
        public string Usrid { get; set; }
        public DateTime? TimeStamp { get; set; }
        public double? Present { get; set; }
        public double? Absent { get; set; }
        public string Upload { get; set; }
        public string Description { get; set; }
        public string EmpGrp { get; set; }
        public double? ClsCl { get; set; }
        public double? ClsSl { get; set; }
        public double? ClsEl { get; set; }
        public double? Holiday { get; set; }
        public double? Vtc { get; set; }
        public double? R { get; set; }
        public double? OpnR { get; set; }
        public double? ClsR { get; set; }
        public string CompanyCode { get; set; }
        public string ProfitCenterCode { get; set; }
        public string Active { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSalaryParameters
    {
        public decimal SalaryParameterId { get; set; }
        public decimal MonthId { get; set; }
        public string MonthName { get; set; }
        public decimal? DaysInMonth { get; set; }
        public decimal? DaAmount { get; set; }
        public decimal? DaPercentage { get; set; }
        public decimal? HraAmount { get; set; }
        public decimal? HraPercentage { get; set; }
        public decimal? PfRange { get; set; }
        public decimal? EsiRange { get; set; }
        public decimal? EsiPercentage { get; set; }
        public decimal? EpfPercentage { get; set; }
        public decimal? FpfPercentage { get; set; }
        public decimal? BonusRange { get; set; }
        public decimal? ProfitTax { get; set; }
        public string EsiArears { get; set; }
        public int? IsActive { get; set; }
    }
}

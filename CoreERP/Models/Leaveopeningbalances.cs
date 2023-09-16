using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Leaveopeningbalances
    {
        public string Code { get; set; }
        public double Cl { get; set; }
        public int Clopbalance { get; set; }
        public double ComOff { get; set; }
        public int ComOffOpbalance { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyDesc { get; set; }
        public double El { get; set; }
        public int Elopbalance { get; set; }
        public double Lp { get; set; }
        public int Lpopbalance { get; set; }
        public string LeaveType { get; set; }
        public double Ml { get; set; }
        public int Mlopbalance { get; set; }
        public string Name { get; set; }
        public double NoOfDays { get; set; }
        public double Pl { get; set; }
        public int Plopbalance { get; set; }
        public double Sl { get; set; }
        public int Slopbalance { get; set; }
        public string Year { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

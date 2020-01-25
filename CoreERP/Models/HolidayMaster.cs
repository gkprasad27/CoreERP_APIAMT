using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class HolidayMaster
    {
        public DateTime Date { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyDesc { get; set; }
        public string Divisions { get; set; }
        public string Holiday { get; set; }
        public string Holidaytype { get; set; }
        public string Location { get; set; }
        public string ProfitCenterCode { get; set; }
        public string Remarks { get; set; }
        public string TimeStamp { get; set; }
        public string Userid { get; set; }
        public string Year { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

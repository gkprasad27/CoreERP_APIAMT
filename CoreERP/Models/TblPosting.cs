using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPosting
    {
        public string Code { get; set; }
        public string Tdstype { get; set; }
        public string IncomeType { get; set; }
        public string Tdsrate { get; set; }
        public string Glaccount { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public string Ext { get; set; }
    }
}

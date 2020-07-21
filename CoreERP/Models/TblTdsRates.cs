using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTdsRates
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Desctiption { get; set; }
        public string Tdstype { get; set; }
        public string IncomeType { get; set; }
        public string Status { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public string Ext { get; set; }
    }
}

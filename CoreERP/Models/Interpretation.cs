using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Interpretation
    {
        public string Code { get; set; }
        public string DiscountReceivedAc { get; set; }
        public bool DiscountReceivedboolAc { get; set; }
        public string DiscountallowAc { get; set; }
        public bool DiscountallowboolAc { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Ext3 { get; set; }
        public string Ext4 { get; set; }
        public string FrightAc { get; set; }
        public bool FrightboolAc { get; set; }
        public string InstallationChargesAc { get; set; }
        public bool InstallationboolAc { get; set; }
        public string OtherExpensesAc { get; set; }
        public bool OtherExpensesboolAc { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class CustomerReceipts
    {
        public string Code { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public string AdjAmount { get; set; }
        public string Amount { get; set; }
        public string BranchCode { get; set; }
        public string CompCode { get; set; }
        public string CreditAcc { get; set; }
        public string DebitAcc { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string ItemReference { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string ReceiptFrom { get; set; }
        public string ReceiptNo { get; set; }
        public string Type { get; set; }
        public DateTime CheckDate { get; set; }
        public string CheckNo { get; set; }
        public string PartyNo { get; set; }
    }
}

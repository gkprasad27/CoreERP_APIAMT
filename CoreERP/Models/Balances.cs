using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Balances
    {
        public int Code { get; set; }
        public string AccountName { get; set; }
        public string BranchCode { get; set; }
        public string CompCode { get; set; }
        public string CrAmount { get; set; }
        public string DrAmount { get; set; }
        public DateTime? Date { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Ext3 { get; set; }
        public string TransactionNo { get; set; }
        public string Glaccount { get; set; }
        public string TransactionType { get; set; }
        public string Ext4 { get; set; }
        public string Ext5 { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

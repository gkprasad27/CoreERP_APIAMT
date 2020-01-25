using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class MatTranTypes
    {
        public int SeqId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DrCrIndicator { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Ext3 { get; set; }
        public string Ext4 { get; set; }
        public string NoSeries { get; set; }
        public string TransactionType { get; set; }
        public string Type { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

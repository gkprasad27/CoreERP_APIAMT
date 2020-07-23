using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPaymentTerms
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? Term1Days { get; set; }
        public int? Term1Discount { get; set; }
        public int? Term2Days { get; set; }
        public int? Term2Discount { get; set; }
        public int? Term3Days { get; set; }
        public int? Term3Discount { get; set; }
        public int? Term4Days { get; set; }
        public int? Term4Discount { get; set; }
        public string Ext { get; set; }
    }
}

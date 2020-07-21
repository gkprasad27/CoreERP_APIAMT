using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignmentVoucherSeriestoVoucherType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string VoucherType { get; set; }
        public string VoucherClass { get; set; }
        public string Ext { get; set; }
    }
}

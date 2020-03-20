using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVoucherTypes
    {
        public decimal VoucherTypeId { get; set; }
        public string VoucherTypeName { get; set; }
        public string TypeOfVoucher { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Narration { get; set; }
        public bool? IsActive { get; set; }
    }
}

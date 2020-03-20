using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblCurrentTransation
    {
        public decimal FormId { get; set; }
        public string VoucherNo { get; set; }
        public decimal? UserId { get; set; }
        public string UserName { get; set; }
        public int TransationStatus { get; set; }
        public DateTime? ServerDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_OrderSwapDetails")]
    public partial class TblOrderSwapDetails
    {
        public int Id { get; set; }
        public int? SwapID { get; set; }
        public int? Qty { get; set; }
        public int? AllocatedQty { get; set; }
        public string? MaterialCode { get; set; }
        public string? SaleOrderNo { get; set; }
        public string? AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        public DateTime? EditDate { get; set; }
        public string? ProductionTag { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("Tbl_OrderSwap")]
    public partial class TblOrderSwap
    {
       
        public int Id { get; set; }
        public string? FromSaleOrder { get; set; }
        public string? ToSaleOrder { get; set; }
        public string? Company { get; set; }
        public string? FromCustomer { get; set; }
        public string? ToCustomer { get; set; }
        public string? AddWho { get; set; }
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        public DateTime? EditDate { get; set; }
    }
}

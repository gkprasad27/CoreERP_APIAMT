using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Erpuser
    {
        public int SeqId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string CanEdit { get; set; }
        public string CanDelete { get; set; }
        public string CanAdd { get; set; }
        public string BranchCode { get; set; }
        public string CompanyCode { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class TblGoodsIssueMaster
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int GoodsIssueId { get; set; }
        public string? Company { get; set; }
        public string? StoresPerson { get; set; }
        public string? ProfitCenter { get; set; }
        public string? Department { get; set; }
        public string? SaleOrderNumber { get; set; }
        public string? ProductionPerson { get; set; }
        public string? Status { get; set; }
        public string? SaleOrder { get;set; }
        public string? StoresPersonName { get; set; }
        public string? ProductionPersonName { get; set; }
        public string? CompanyName { get; set; }
        public string? DepartmentName { get; set; }
        public string? ProfitcenterName { get; set; }

        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }
    }
}

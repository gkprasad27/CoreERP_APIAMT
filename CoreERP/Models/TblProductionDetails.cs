using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblProductionDetails
    {
        public int ID { get; set; }
        public string? SaleOrderNumber { get; set; }
        public string? ProductionTag { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? AllocatedPerson { get; set; }
        public string? TypeofWork { get; set; }
        public string? Remarks  { get; set; }
        public decimal Duration { get; set; }
    }
}

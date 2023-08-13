using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblWbs
    {
        public string? CostUnit { get; set; }
        public string? Wbscode { get; set; }
        public string? Description { get; set; }
        public string? ResponsiblePerson { get; set; }
        public string? Deliverables { get; set; }
        public string? Risk { get; set; }
        public string? MileStones { get; set; }
        public string? AdditionalInformation { get; set; }
        public string? Approvals { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Duration { get; set; }
        public DateTime? EndDate { get; set; }
        public string? UnderWbs { get; set; }
    }
}

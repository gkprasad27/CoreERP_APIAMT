using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBatchMaster
    {
        public string Company { get; set; }
        public string Plant { get; set; }
        public string BatchNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string Year { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }
        public string BatchSize { get; set; }
        public int? Uom { get; set; }
        public string PlantStart { get; set; }
        public DateTime? PlantEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public TimeSpan? ActualStartTime { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public TimeSpan? ActualEndTime { get; set; }
    }
}

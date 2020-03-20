using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblOilConversionMaster
    {
        public decimal OilConversionMasterId { get; set; }
        public decimal? BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string OilConversionVchNo { get; set; }
        public decimal? VoucherTypeId { get; set; }
        public DateTime? OilConversionDate { get; set; }
        public string Narration { get; set; }
        public decimal? UserId { get; set; }
        public string UserName { get; set; }
        public decimal? EmployeeId { get; set; }
        public decimal? ShiftId { get; set; }
        public DateTime? ServerDate { get; set; }
    }
}

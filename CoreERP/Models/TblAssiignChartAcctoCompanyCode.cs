using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssiignChartAcctoCompanyCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Company { get; set; }
        public string OperationCoa { get; set; }
        public string GroupCoa { get; set; }
    }
}

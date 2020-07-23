using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignchartaccttoCompanycode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string OperationCoa { get; set; }
        public string GroupCoa { get; set; }
    }
}

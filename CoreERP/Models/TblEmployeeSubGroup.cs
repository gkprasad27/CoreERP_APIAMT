using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblEmployeeSubGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string EmpGroupCode { get; set; }
        public string Ext { get; set; }
    }
}

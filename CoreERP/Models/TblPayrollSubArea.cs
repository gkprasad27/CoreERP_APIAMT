using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPayrollSubArea
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PayrollArea { get; set; }
        public string Ext1 { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblFieldsConfiguration
    {
        public int Id { get; set; }
        public string OperationCode { get; set; }
        public string ScreenName { get; set; }
        public string ShowControl { get; set; }
        public string CompanyCode { get; set; }
    }
}

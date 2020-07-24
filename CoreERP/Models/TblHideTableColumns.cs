using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblHideTableColumns
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Company { get; set; }
        public string AliasName { get; set; }
    }
}

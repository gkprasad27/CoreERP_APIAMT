using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblDynamicPages
    {
        public int Id { get; set; }
        public string FormName { get; set; }
        public string Url { get; set; }
        public string Component { get; set; }
        public string RegisterUrl { get; set; }
        public string UpdateUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string ListName { get; set; }
        public string PrimaryKey { get; set; }
        public string Ext { get; set; }
    }
}

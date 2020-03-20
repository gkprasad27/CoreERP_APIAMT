using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblFormMenuCollection
    {
        public int FormId { get; set; }
        public string FormName { get; set; }
        public decimal? MainMenu { get; set; }
        public string MainMenuName { get; set; }
        public decimal? SubMenu { get; set; }
        public string SubMenuName { get; set; }
        public bool? Enable { get; set; }
    }
}

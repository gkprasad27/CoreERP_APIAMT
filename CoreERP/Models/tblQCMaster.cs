using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class tblQCMaster
    {
        public string Code { get; set; }       
        public string? Type { get; set; }
        public bool? IsActive { get; set; }
        public string? MaterialCode { get; set; }
        public string? TagName { get; set; }

    }
}

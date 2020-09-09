using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPermissions
    {
        public int SeqId { get; set; }
        public string Username { get; set; }
        public bool CanEdit { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanAdd { get; set; }
        public bool CanView { get; set; }
        public string ScreenModule { get; set; }
        public string ScreenName { get; set; }
    }
}

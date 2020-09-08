using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblFieldsConfiguration
    {
        public int Id { get; set; }
        public string ScreenModule { get; set; }
        public string Screenname { get; set; }
        public string Configuration { get; set; }
        public string UserName { get; set; }
    }
}

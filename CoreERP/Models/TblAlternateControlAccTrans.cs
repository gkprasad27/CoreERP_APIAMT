using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAlternateControlAccTrans
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string NormalControlAccount { get; set; }
        public string AlternativeControlAccount { get; set; }
    }
}

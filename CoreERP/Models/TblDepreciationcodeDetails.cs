using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblDepreciationcodeDetails
    {
        public int Id { get; set; }
        public string DepreciationCode { get; set; }
        public string Yearsupto { get; set; }
        public string Monthupto { get; set; }
        public string Rateupto { get; set; }
    }
}

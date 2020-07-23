using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTaxtransactions
    {
        public int Id { get; set; }
        public byte[] Code { get; set; }
        public string Description { get; set; }
    }
}

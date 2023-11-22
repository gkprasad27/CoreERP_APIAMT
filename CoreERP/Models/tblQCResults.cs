using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class tblQCResults
    {
        public int Id { get; set; }
        public string? Result { get; set; }
        public string? Parameter { get; set; }
        public string? Uom { get; set; }
        public string? Spec { get; set; }
        public string? MinValue { get; set; }
        public string? MaxValue { get; set; }
        public string? Instrument { get; set; }
        public string? Type { get; set; }
        public bool? IsActive { get; set; }
        public string? MaterialCode { get; set; }
        public string? TagName { get; set; }

    }
}

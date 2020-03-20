using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblDetails
    {
        public int DetailsId { get; set; }
        public int? MasterId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int? Row { get; set; }
        public int? Columns { get; set; }
        public int? Width { get; set; }
        public string Dbf { get; set; }
        public string DorH { get; set; }
        public string Repeat { get; set; }
        public string Align { get; set; }
        public string RepeatAll { get; set; }
        public string FooterRepeatAll { get; set; }
        public string TextWrap { get; set; }
        public int? WrapLineCount { get; set; }
        public string ExtraFieldName { get; set; }
        public string FieldsForExtra { get; set; }
    }
}

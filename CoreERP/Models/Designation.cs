using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Designation
    {
        public string DesigCode { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyDesc { get; set; }
        public string CompanyGroupCode { get; set; }
        public string DesigName { get; set; }
        public string DesigShortName { get; set; }
        public string GradeCode { get; set; }
        public string Formno { get; set; }
        public string TimeStamp { get; set; }
        public string Trmno { get; set; }
        public string Usrid { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

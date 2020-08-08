using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblLanguage
    {
        public TblLanguage()
        {
            Countries = new HashSet<Countries>();
            States = new HashSet<States>();
        }

        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
        public virtual ICollection<States> States { get; set; }
    }
}

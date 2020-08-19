using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Models
{
   partial class Countries
    {
        [NotMapped]
        public string LangName { get; set; }
        [NotMapped]
        public string CurrName { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Segment
    {
        public int SeqId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

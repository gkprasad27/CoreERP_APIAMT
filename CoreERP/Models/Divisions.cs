﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Divisions
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Ext1 { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Active { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class Ledger
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string LedgerType { get; set; }
        public string Ext { get; set; }
    }
}

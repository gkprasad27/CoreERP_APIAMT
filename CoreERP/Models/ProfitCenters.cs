﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class ProfitCenters
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Active { get; set; }
        public string Email { get; set; }
        public string Ext { get; set; }
        public string Ext1 { get; set; }
    }
}

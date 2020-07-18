﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblBranch
    {
        public int Id { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string CompanyCode { get; set; }
        public int? IsMainBranch { get; set; }
        public int SubBranchof { get; set; }
        public byte[] BranchImage { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string Address2 { get; set; }
        public string Panno { get; set; }
        public string Gstno { get; set; }
        public string Tanno { get; set; }
        public string Ext { get; set; }
        public string Ext1 { get; set; }
    }
}

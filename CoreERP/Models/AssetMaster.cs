using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class AssetMaster
    {
        public string Code { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public DateTime? AquationDate { get; set; }
        public decimal AquationValue { get; set; }
        public string AsseetName { get; set; }
        public string AssetNo { get; set; }
        public string CompCode { get; set; }
        public string DepresiationUptoDate { get; set; }
        public string Email { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Glcode { get; set; }
        public string MeasureofDepresiation { get; set; }
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string PinCode { get; set; }
        public string Place { get; set; }
        public string RateOfDeprecation { get; set; }
        public string State { get; set; }
        public string UsefulHike { get; set; }
        public string UsefulHikemonth { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

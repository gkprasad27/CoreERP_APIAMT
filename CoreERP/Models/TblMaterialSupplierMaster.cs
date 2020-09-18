using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblMaterialSupplierMaster
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Place { get; set; }
        public string State { get; set; }
        public string TransportMethod { get; set; }
        public string DeliveryTime { get; set; }
        public string ContactPerson { get; set; }
        public string Narration { get; set; }
    }
}

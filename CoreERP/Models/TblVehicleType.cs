using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVehicleType
    {
        public decimal VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public DateTime? AddDate { get; set; }
    }
}

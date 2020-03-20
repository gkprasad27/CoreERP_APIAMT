using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblVehicleType
    {
        public TblVehicleType()
        {
            TblVehicle = new HashSet<TblVehicle>();
        }

        public decimal VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }

        public virtual ICollection<TblVehicle> TblVehicle { get; set; }
    }
}

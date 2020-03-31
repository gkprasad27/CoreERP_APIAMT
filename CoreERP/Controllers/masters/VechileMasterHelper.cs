using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    public class VechileMasterHelper
    {
        public List<TblVehicle> GetVehicles(string  vachileRegNo, decimal? memberCode)
        {
            try
            {
                if (memberCode == 0)
                    memberCode = null;

                using Repository<TblVehicle> repo = new Repository<TblVehicle>();
                return repo.TblVehicle.Where(v => v.VehicleRegNo.ToLower().Contains(vachileRegNo.ToLower()) && v.MemberCode == (memberCode ?? v.MemberCode)).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

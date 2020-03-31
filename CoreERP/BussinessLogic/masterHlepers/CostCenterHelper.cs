using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class CostCenterHelper
    {
        public static List<CostCenters> GetCostCenterList()
        {
            try
            {
                using Repository<CostCenters> repo = new Repository<CostCenters>();
                return repo.CostCenters.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch { throw; }
        }

        public static bool IsCodeExists(string code)
        {
            try
            {
                using Repository<CostCenters> repo = new Repository<CostCenters>();
                return repo.CostCenters
.AsEnumerable()
.Where(c => c.Code == code)
.Count() > 0;
            }
            catch { throw; }
        }

        public static CostCenters RegisterCostCenter(CostCenters costCenter)
        {
            try
            {
                using Repository<CostCenters> repo = new Repository<CostCenters>();
                costCenter.Active = "Y";
                repo.CostCenters.Add(costCenter);
                if (repo.SaveChanges() > 0)
                    return costCenter;

                return null;
            }
            catch { throw; }
        }



        public static CostCenters UpdateCostCenter(CostCenters costCenters)
        {
            try
            {
                using Repository<CostCenters> repo = new Repository<CostCenters>();
                repo.CostCenters.Update(costCenters);
                if (repo.SaveChanges() > 0)
                    return costCenters;

                return null;
            }
            catch { throw; }
        }



        public static CostCenters DeleteCostCenter(string costCenterCode)
        {
            try
            {
                using Repository<CostCenters> repo = new Repository<CostCenters>();
                var costcntr = repo.CostCenters.Where(c => c.Code == costCenterCode).FirstOrDefault();
                costcntr.Active = "N";
                repo.CostCenters.Update(costcntr);
                if (repo.SaveChanges() > 0)
                    return costcntr;

                return null;
            }
            catch { throw; }
        }
    }
}

using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class ProfitCenterHelper
    {

        public static List<ProfitCenters> GetProfitCenterList()
        {
            try
            {
                using (Repository<ProfitCenters> repo = new Repository<ProfitCenters>())
                {
                    return repo.ProfitCenters.AsEnumerable().Where(p => p.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }
        public static ProfitCenters RegisteProfitCenter(ProfitCenters profitCenter)
        {
            try
            {
                using (Repository<ProfitCenters> repo = new Repository<ProfitCenters>())
                {
                    profitCenter.Active = "Y";
                    profitCenter.AddDate = DateTime.Now;
                    repo.ProfitCenters.Add(profitCenter);
                    if (repo.SaveChanges() > 0)
                        return profitCenter;

                    return null;
                }
            }
            catch { throw; }
        }
        public static ProfitCenters UpdateProfitCenter(ProfitCenters profitCenter)
        {
            try
            {
                using (Repository<ProfitCenters> repo = new Repository<ProfitCenters>())
                {
                    repo.ProfitCenters.Update(profitCenter);
                    if (repo.SaveChanges() > 0)
                        return profitCenter;

                    return null;
                }
            }
            catch { throw; }
        }
        public static ProfitCenters DeleteProfitCenter(int seqID)
        {
            try
            {
                using (Repository<ProfitCenters> repo = new Repository<ProfitCenters>())
                {
                    var prftcntr = repo.ProfitCenters.Where(p => p.SeqId == seqID).FirstOrDefault();
                    prftcntr.Active = "N";
                    repo.ProfitCenters.Update(prftcntr);
                    if (repo.SaveChanges() > 0)
                        return prftcntr;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}

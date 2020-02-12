using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SelfserviceHelpers
{
    public class ApplyodHelper
    {
        public static List<ApplyOddata> GetApplyodDetailsList()
        {
            try
            {
                using (Repository<ApplyOddata> repo = new Repository<ApplyOddata>())
                {
                    return repo.ApplyOddata.AsEnumerable().ToList();
                }
            }
            catch { throw; }
        }

        public static ApplyOddata RegisterApplyOddataDetails(ApplyOddata applyOddata)
        {
            try
            {
                using (Repository<ApplyOddata> repo = new Repository<ApplyOddata>())
                {
                    applyOddata.Status = "Applied";
                    applyOddata.ApplDate = DateTime.Now;
                    repo.ApplyOddata.Add(applyOddata);
                    if (repo.SaveChanges() > 0)
                        return applyOddata;
                    return null;
                }
            }
            catch { throw; }
        }
    }
}

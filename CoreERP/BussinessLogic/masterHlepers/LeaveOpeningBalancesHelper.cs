using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class LeaveOpeningBalancesHelper
    {
        public static List<Leaveopeningbalances> GetListOfLeaveopeningbalances()
        {
            try
            {
                using (Repository<Leaveopeningbalances> repo = new Repository<Leaveopeningbalances>())
                {
                    return repo.Leaveopeningbalances.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }
        public static Leaveopeningbalances GetLeaveopeningbalances(string compCode)
        {
            try
            {
                using (Repository<Leaveopeningbalances> repo = new Repository<Leaveopeningbalances>())
                {
                    return repo.Leaveopeningbalances.AsEnumerable()
                               .Where(x => x.CompanyCode.Equals(compCode))
                                         .FirstOrDefault();
                }
            }
            catch { throw; }
        }
        public static List<Leaveopeningbalances> SearchLeaveopeningbalances(string lopcode)
    {
      try
      {
        using (Repository<Leaveopeningbalances> repo = new Repository<Leaveopeningbalances>())
        {
          return repo.Leaveopeningbalances.AsEnumerable()
            .Where(b => b.Code == lopcode
                     && b.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
                  )
            .ToList();
        }
      }
      catch { throw; }
    }
        public static Leaveopeningbalances Register(Leaveopeningbalances lop)
        {
            try
            {
                using (Repository<Leaveopeningbalances> repo = new Repository<Leaveopeningbalances>())
                {
                   lop.Active = "Y";
                    repo.Leaveopeningbalances.Add(lop);
                    if (repo.SaveChanges() > 0)
                        return lop;

                    return null;
                }
            }
            catch { throw; }
        }
        public static Leaveopeningbalances Update(Leaveopeningbalances lop)
        {
            try
            {
                using (Repository<Leaveopeningbalances> repo = new Repository<Leaveopeningbalances>())
                {
                    repo.Leaveopeningbalances.Update(lop);
                    if (repo.SaveChanges() > 0)
                        return lop;

                    return null;
                }
            }
            catch { throw; }
        }
        public static Leaveopeningbalances DeleteLeaveopeningbalances(string code)
        {
            try
            {
                using (Repository<Leaveopeningbalances> repo = new Repository<Leaveopeningbalances>())
                {
                    var lop = repo.Leaveopeningbalances.Where(x => x.CompanyCode == code).FirstOrDefault();
                     lop.Active = "N";
                    repo.Leaveopeningbalances.Update(lop);
                    if (repo.SaveChanges() > 0)
                        return lop;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}

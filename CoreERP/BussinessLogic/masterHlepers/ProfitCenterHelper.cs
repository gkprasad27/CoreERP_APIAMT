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
    private static Repository<ProfitCenters> _repo = null;
    private static Repository<ProfitCenters> repo
    {
      get
      {
        if (_repo == null)
          _repo = new Repository<ProfitCenters>();
        return _repo;
      }
    }

    public static List<ProfitCenters> GetProfitCenterList()
    {
      try
      {
        return repo.ProfitCenters.Select(p => p).ToList();
      }
      catch { throw; }
    }

    public static int RegisteProfitCenter(ProfitCenters profitCenter)
    {
      try
      {
        repo.ProfitCenters.Add(profitCenter);
        return repo.SaveChanges();
      }
      catch { throw; }
    }

    public static int UpdateProfitCenter(ProfitCenters profitCenter)
    {
      try
      {
        repo.ProfitCenters.Update(profitCenter);
        return repo.SaveChanges();
      }
      catch { throw; }
    }


    public static int DeleteProfitCenter(string profitCenterCode)
    {
      try
      {
        var prftcntr = repo.ProfitCenters.Where(p => p.Code == profitCenterCode).FirstOrDefault();
        repo.ProfitCenters.Remove(prftcntr);
        return repo.SaveChanges();
      }
      catch { throw; }
    }
  }
}

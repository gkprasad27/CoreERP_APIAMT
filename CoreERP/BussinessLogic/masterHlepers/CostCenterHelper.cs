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
    private static Repository<CostCenters> _repo = null;
    private static Repository<CostCenters> repo
    {
      get
      {
        if (_repo == null)
          _repo = new Repository<CostCenters>();
        return _repo;
      }
    }

    public static List<CostCenters> GetCostCenterList()
    {
      try
      {
        return repo.CostCenters.Select(c => c).ToList();
      }
      catch { throw; }
    }



    public static int RegisterCostCenter(CostCenters costCenter)
    {
      try
      {
        repo.CostCenters.Add(costCenter);
        return repo.SaveChanges();
      }
      catch { throw; }
    }



    public static int UpdateCostCenter(CostCenters costCenters)
    {
      try
      {
        repo.CostCenters.Update(costCenters);
        return repo.SaveChanges();
      }
      catch { throw; }
    }



    public static int DeleteCostCenter(string costCenterCode)
    {
      try
      {
        var costcntr = repo.CostCenters.Where(c => c.Code == costCenterCode).FirstOrDefault();
        repo.CostCenters.Remove(costcntr);
        return repo.SaveChanges();
      }
      catch { throw; }
    }
  }
}

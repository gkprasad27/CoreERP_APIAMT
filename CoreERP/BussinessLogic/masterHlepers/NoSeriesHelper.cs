using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
  public class NoSeriesHelper
  {
    private static Repository<NoSeries> _repo = null;
    private static Repository<NoSeries> repo
    {
      get
      {
        if (_repo == null)
          _repo = new Repository<NoSeries>();
        return _repo;
      }
    }

    public static List<NoSeries> GetAllNoSeriesLists()
    {
      try
      {
        return repo.NoSeries.Select(n => n).ToList();
      }
      catch { throw; }
    }

    public static int RegisteNoSeries(NoSeries noSeries)
    {
      try
      {
        var record = ((from noseries in repo.NoSeries select noseries.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
        if(record!=0)
        {
          noSeries.Code=(record + 1).ToString();
        }
        else
          noSeries.Code = "1";
        repo.NoSeries.Add(noSeries);
        return repo.SaveChanges();
      }
      catch { throw; }
    }

    public static int UpdateNoSeries(NoSeries noSeries)
    {
      try
      {
        repo.NoSeries.Update(noSeries);
        return repo.SaveChanges();
      }
      catch { throw; }
    }

    public static int DeleteNoSeries(string noSeriesCode)
    {
      try
      {
        var noseries = repo.NoSeries.Where(n => n.Code == noSeriesCode).FirstOrDefault();
        repo.NoSeries.Remove(noseries);
        return repo.SaveChanges();
      }
      catch { throw; }
    }
  }
}

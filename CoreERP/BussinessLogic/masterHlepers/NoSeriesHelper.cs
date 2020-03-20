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

        //public static List<NoSeries> GetAllNoSeriesLists()
        //{
        //    try
        //    {
        //        using (Repository<NoSeries> repo = new Repository<NoSeries>())
        //        {
        //            return repo.NoSeries.AsEnumerable().Where(n => n.Active.Equals("Y",StringComparison.OrdinalIgnoreCase)).ToList();
        //        }
        //    }
        //    catch { throw; }
        //}
        //public static NoSeries RegisteNoSeries(NoSeries noSeries)
        //{
        //    try
        //    {
        //        using (Repository<NoSeries> repo = new Repository<NoSeries>())
        //        {
        //            noSeries.Active = "Y";

        //            var record = ((from noseries in repo.NoSeries select noseries.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
        //            if (record != 0)
        //            {
        //                noSeries.Code = (record + 1).ToString();
        //            }
        //            else
        //                noSeries.Code = "1";
        //            repo.NoSeries.Add(noSeries);
        //            if (repo.SaveChanges() > 0)
        //                return noSeries;

        //            return null;
        //        }
        //    }
        //    catch { throw; }
        //}
        //public static NoSeries UpdateNoSeries(NoSeries noSeries)
        //{
        //    try
        //    {
        //        using (Repository<NoSeries> repo = new Repository<NoSeries>())
        //        {
        //            repo.NoSeries.Update(noSeries);
        //            if (repo.SaveChanges() > 0)
        //                return noSeries;

        //            return null;
        //        }
        //    }
        //    catch { throw; }
        //}
        //public static NoSeries DeleteNoSeries(string noSeriesCode)
        //{
        //    try
        //    {
        //        using (Repository<NoSeries> repo = new Repository<NoSeries>())
        //        {
        //            var noseries = repo.NoSeries.Where(n => n.Code == noSeriesCode).FirstOrDefault();
        //            noseries.Active = "N";
        //            repo.NoSeries.Remove(noseries);
        //            if (repo.SaveChanges() > 0)
        //                return noseries;
        //            return null;
        //        }
        //    }
        //    catch { throw; }
        //}
  }
}

using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class LocationHelper
    {
        //public static IEnumerable<TblLocation> GetList(string locid)
        //{
        //    try
        //    {
        //        return Repository<TblLocation>.Instance.Where(x => x.LocationId == locid);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblPlant> GetPlants()
        //{
        //    try
        //    {
        //        return Repository<TblPlant>.Instance.GetAll().OrderBy(x => x.PlantCode);
        //    }
        //    catch { throw; }
        //}
        //public static IEnumerable<TblLocation> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblLocation>.Instance.GetAll().OrderBy(x => x.LocationId);
        //    }
        //    catch { throw; }
        //}

        //public static TblLocation Register(TblLocation loc)
        //{
        //    try
        //    {
        //        Repository<TblLocation>.Instance.Add(loc);
        //        if (Repository<TblLocation>.Instance.SaveChanges() > 0)
        //            return loc;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblLocation Update(TblLocation loc)
        //{
        //    try
        //    {
        //        Repository<TblLocation>.Instance.Update(loc);
        //        if (Repository<TblLocation>.Instance.SaveChanges() > 0)
        //            return loc;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblLocation Delete(string loccode)
        //{
        //    try
        //    {
        //        var ccode = Repository<TblLocation>.Instance.GetSingleOrDefault(x => x.LocationId == loccode);
        //        Repository<TblLocation>.Instance.Remove(ccode);
        //        if (Repository<TblLocation>.Instance.SaveChanges() > 0)
        //            return ccode;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

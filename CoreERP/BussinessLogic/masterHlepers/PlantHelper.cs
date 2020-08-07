using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class PlantHelper
    {
        //public static IEnumerable<TblPlant> GetList(string plant)
        //{
        //    try
        //    {
        //        return Repository<TblPlant>.Instance.Where(x => x.PlantCode == plant);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblPlant> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblPlant>.Instance.GetAll().OrderBy(x => x.PlantCode);
        //    }
        //    catch { throw; }
        //}

        //public static TblPlant Register(TblPlant plant)
        //{
        //    try
        //    {
        //        Repository<TblPlant>.Instance.Add(plant);
        //        if (Repository<TblPlant>.Instance.SaveChanges() > 0)
        //            return plant;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblPlant Update(TblPlant plant)
        //{
        //    try
        //    {
        //        Repository<TblPlant>.Instance.Update(plant);
        //        if (Repository<TblPlant>.Instance.SaveChanges() > 0)
        //            return plant;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblPlant Delete(string code)
        //{
        //    try
        //    {
        //        var ccode = Repository<TblPlant>.Instance.GetSingleOrDefault(x => x.PlantCode == code);
        //        Repository<TblPlant>.Instance.Remove(ccode);
        //        if (Repository<TblPlant>.Instance.SaveChanges() > 0)
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

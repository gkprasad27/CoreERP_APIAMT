using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class DivisionHelper
    {

        //public static IEnumerable<Divisions> GetList(string divisionCode)
        //{
        //    try
        //    {
        //        return Repository<Divisions>.Instance.Where(x => x.Code == divisionCode);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<Divisions> GetList()
        //{
        //    try
        //    {
        //        return Repository<Divisions>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        //public static Divisions Register(Divisions divisions)
        //{
        //    try
        //    {
        //        Repository<Divisions>.Instance.Add(divisions);
        //        if (Repository<Divisions>.Instance.SaveChanges() > 0)
        //            return divisions;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static Divisions Update(Divisions division)
        //{
        //    try
        //    {
        //        Repository<Divisions>.Instance.Update(division);
        //        if (Repository<Divisions>.Instance.SaveChanges() > 0)
        //            return division;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static Divisions Delete(string divisionCode)
        //{
        //    try
        //    {
        //        var ccode = Repository<Divisions>.Instance.GetSingleOrDefault(x => x.Code == divisionCode);
        //        Repository<Divisions>.Instance.Remove(ccode);
        //        if (Repository<Divisions>.Instance.SaveChanges() > 0)
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

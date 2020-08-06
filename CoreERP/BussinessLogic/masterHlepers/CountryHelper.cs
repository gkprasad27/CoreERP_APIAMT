using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class CountryHelper
    {
        //public static IEnumerable<Countries> GetList(string countrycode)
        //{
        //    try
        //    {
        //        return Repository<Countries>.Instance.Where(x => x.CountryCode == countrycode);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<Countries> GetList()
        //{
        //    try
        //    {
        //        return Repository<Countries>.Instance.GetAll().OrderBy(x => x.CountryCode);
        //    }
        //    catch { throw; }
        //}

        //public static Countries Register(Countries country)
        //{
        //    try
        //    {
        //        Repository<Countries>.Instance.Add(country);
        //        if (Repository<Countries>.Instance.SaveChanges() > 0)
        //            return country;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static Countries Update(Countries country)
        //{
        //    try
        //    {
        //        Repository<Countries>.Instance.Update(country);
        //        if (Repository<Countries>.Instance.SaveChanges() > 0)
        //            return country;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static Countries Delete(string countrycode)
        //{
        //    try
        //    {
        //        var ccode = Repository<Countries>.Instance.GetSingleOrDefault(x => x.CountryCode == countrycode);
        //        Repository<Countries>.Instance.Remove(ccode);
        //        if (Repository<Countries>.Instance.SaveChanges() > 0)
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

using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class LanguageHelper
    {
        //public static IEnumerable<TblLanguage> GetList(string language)
        //{
        //    try
        //    {
        //        return Repository<TblLanguage>.Instance.Where(x => x.LanguageCode == language);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblLanguage> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblLanguage>.Instance.GetAll().OrderBy(x => x.LanguageCode);
        //    }
        //    catch { throw; }
        //}

        //public static TblLanguage Register(TblLanguage language)
        //{
        //    try
        //    { 
        //        Repository<TblLanguage>.Instance.Add(language);
        //        if (Repository<TblLanguage>.Instance.SaveChanges() > 0)
        //            return language;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblLanguage Update(TblLanguage language)
        //{
        //    try
        //    {
        //        Repository<TblLanguage>.Instance.Update(language);
        //        if (Repository<TblLanguage>.Instance.SaveChanges() > 0)
        //            return language;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblLanguage Delete(string rcodes)
        //{
        //    try
        //    {

        //        var rcode = Repository<TblLanguage>.Instance.GetSingleOrDefault(x => x.LanguageCode == rcodes);
        //        Repository<TblLanguage>.Instance.Remove(rcode);
        //        if (Repository<TblLanguage>.Instance.SaveChanges() > 0)
        //            return rcode;
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

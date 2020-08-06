using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class CurrencyHelper
    {
        //public static IEnumerable<TblCurrency> GetList(string currency)
        //{
        //    try
        //    {
        //        return Repository<TblCurrency>.Instance.Where(x => x.CurrencySymbol == currency);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblCurrency> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblCurrency>.Instance.GetAll().OrderBy(x=>x.CurrencySymbol);
        //    }
        //    catch { throw; }
        //}

        //public static TblCurrency Register(TblCurrency currency)
        //{
        //    try
        //    {
        //        Repository<TblCurrency>.Instance.Add(currency);                
        //        if (Repository<TblCurrency>.Instance.SaveChanges() > 0)
        //            return currency;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblCurrency Update(TblCurrency currency)
        //{
        //    try
        //    {   
        //        Repository<TblCurrency>.Instance.Update(currency);
        //        if (Repository<TblCurrency>.Instance.SaveChanges() > 0)
        //            return currency;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblCurrency Delete(string ccodes)
        //{
        //    try
        //    {
                
        //        var ccode = Repository<TblCurrency>.Instance.GetSingleOrDefault( x => x.CurrencySymbol == ccodes);
        //        Repository<TblCurrency>.Instance.Remove(ccode);
        //        if (Repository<TblCurrency>.Instance.SaveChanges() > 0)
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

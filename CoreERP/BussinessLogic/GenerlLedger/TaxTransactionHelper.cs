using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class TaxTransactionHelper
    {
        //public static IEnumerable<TblTaxtransactions> GetList(string code)
        //{
        //    try
        //    {
        //        return Repository<TblTaxtransactions>.Instance.Where(x => x.Code == code);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblTaxtransactions> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblTaxtransactions>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        //public static TblTaxtransactions Register(TblTaxtransactions transaction)
        //{
        //    try
        //    {
        //        Repository<TblTaxtransactions>.Instance.Add(transaction);
        //        if (Repository<TblTaxtransactions>.Instance.SaveChanges() > 0)
        //            return transaction;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblTaxtransactions Update(TblTaxtransactions transaction)
        //{
        //    try
        //    {
        //        Repository<TblTaxtransactions>.Instance.Update(transaction);
        //        if (Repository<TblTaxtransactions>.Instance.SaveChanges() > 0)
        //            return transaction;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblTaxtransactions Delete(string Code)
        //{
        //    try
        //    {
        //        var ccode = Repository<TblTaxtransactions>.Instance.GetSingleOrDefault(x => x.Code == Code);
        //        Repository<TblTaxtransactions>.Instance.Remove(ccode);
        //        if (Repository<TblTaxtransactions>.Instance.SaveChanges() > 0)
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

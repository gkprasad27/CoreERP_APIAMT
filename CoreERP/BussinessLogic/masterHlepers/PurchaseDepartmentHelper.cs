using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class PurchaseDepartmentHelper
    {
        //public static IEnumerable<TblPurchaseDepartment> GetList(string prdept)
        //{
        //    try
        //    {
        //        return Repository<TblPurchaseDepartment>.Instance.Where(x => x.Code == prdept);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblPurchaseDepartment> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblPurchaseDepartment>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        //public static TblPurchaseDepartment Register(TblPurchaseDepartment prdept)
        //{
        //    try
        //    {
        //        Repository<TblPurchaseDepartment>.Instance.Add(prdept);
        //        if (Repository<TblPurchaseDepartment>.Instance.SaveChanges() > 0)
        //            return prdept;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblPurchaseDepartment Update(TblPurchaseDepartment prdept)
        //{
        //    try
        //    {
        //        Repository<TblPurchaseDepartment>.Instance.Update(prdept);
        //        if (Repository<TblPurchaseDepartment>.Instance.SaveChanges() > 0)
        //            return prdept;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblPurchaseDepartment Delete(string prdeptcode)
        //{
        //    try
        //    {
        //        var ccode = Repository<TblPurchaseDepartment>.Instance.GetSingleOrDefault(x => x.Code == prdeptcode);
        //        Repository<TblPurchaseDepartment>.Instance.Remove(ccode);
        //        if (Repository<TblPurchaseDepartment>.Instance.SaveChanges() > 0)
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

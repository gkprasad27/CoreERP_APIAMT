using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class VoucherClassHelper
    {
        //public static IEnumerable<TblVoucherclass> GetList(string code)
        //{
        //    try
        //    {
        //        return Repository<TblVoucherclass>.Instance.Where(x => x.VoucherKey == code);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblVoucherclass> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblVoucherclass>.Instance.GetAll().OrderBy(x => x.VoucherKey);
        //    }
        //    catch { throw; }
        //}

        //public static TblVoucherclass Register(TblVoucherclass vcclass)
        //{
        //    try
        //    {
        //        Repository<TblVoucherclass>.Instance.Add(vcclass);
        //        if (Repository<TblVoucherclass>.Instance.SaveChanges() > 0)
        //            return vcclass;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblVoucherclass Update(TblVoucherclass vcclass)
        //{
        //    try
        //    {
        //        Repository<TblVoucherclass>.Instance.Update(vcclass);
        //        if (Repository<TblVoucherclass>.Instance.SaveChanges() > 0)
        //            return vcclass;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblVoucherclass Delete(string Code)
        //{
        //    try
        //    {
        //        var ccode = Repository<TblVoucherclass>.Instance.GetSingleOrDefault(x => x.VoucherKey == Code);
        //        Repository<TblVoucherclass>.Instance.Remove(ccode);
        //        if (Repository<TblVoucherclass>.Instance.SaveChanges() > 0)
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

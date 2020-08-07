using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class HsnsacHelper
    {
        //public static IEnumerable<TblHsnsac> GetList(string code)
        //{
        //    try
        //    {
        //        return Repository<TblHsnsac>.Instance.Where(x => x.Code == code);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblHsnsac> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblHsnsac>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        //public static TblHsnsac Register(TblHsnsac code)
        //{
        //    try
        //    {
        //        Repository<TblHsnsac>.Instance.Add(code);
        //        if (Repository<TblHsnsac>.Instance.SaveChanges() > 0)
        //            return code;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblHsnsac Update(TblHsnsac code)
        //{
        //    try
        //    {
        //        Repository<TblHsnsac>.Instance.Update(code);
        //        if (Repository<TblHsnsac>.Instance.SaveChanges() > 0)
        //            return code;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblHsnsac Delete(string rcodes)
        //{
        //    try
        //    {

        //        var rcode = Repository<TblHsnsac>.Instance.GetSingleOrDefault(x => x.Code == rcodes);
        //        Repository<TblHsnsac>.Instance.Remove(rcode);
        //        if (Repository<TblHsnsac>.Instance.SaveChanges() > 0)
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

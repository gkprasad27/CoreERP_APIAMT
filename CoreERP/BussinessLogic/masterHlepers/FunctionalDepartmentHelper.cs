using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class FunctionalDepartmentHelper
    {
        //public static IEnumerable<TblFunctionalDepartment> GetList(string fdept)
        //{
        //    try
        //    {
        //        return Repository<TblFunctionalDepartment>.Instance.Where(x => x.Code == fdept);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblFunctionalDepartment> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblFunctionalDepartment>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        //public static TblFunctionalDepartment Register(TblFunctionalDepartment fdept)
        //{
        //    try
        //    {
        //        Repository<TblFunctionalDepartment>.Instance.Add(fdept);
        //        if (Repository<TblFunctionalDepartment>.Instance.SaveChanges() > 0)
        //            return fdept;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblFunctionalDepartment Update(TblFunctionalDepartment fdept)
        //{
        //    try
        //    {
        //        Repository<TblFunctionalDepartment>.Instance.Update(fdept);
        //        if (Repository<TblFunctionalDepartment>.Instance.SaveChanges() > 0)
        //            return fdept;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblFunctionalDepartment Delete(string code)
        //{
        //    try
        //    {
        //        var ccode = Repository<TblFunctionalDepartment>.Instance.GetSingleOrDefault(x => x.Code == code);
        //        Repository<TblFunctionalDepartment>.Instance.Remove(ccode);
        //        if (Repository<TblFunctionalDepartment>.Instance.SaveChanges() > 0)
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

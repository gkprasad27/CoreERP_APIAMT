using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class MaintenanceAreaHelper
    {
        //public static IEnumerable<TblMaintenancearea> GetList(string marea)
        //{
        //    try
        //    {
        //        return Repository<TblMaintenancearea>.Instance.Where(x => x.Code == marea);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblMaintenancearea> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblMaintenancearea>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        //public static TblMaintenancearea Register(TblMaintenancearea marea)
        //{
        //    try
        //    {
        //        Repository<TblMaintenancearea>.Instance.Add(marea);
        //        if (Repository<TblMaintenancearea>.Instance.SaveChanges() > 0)
        //            return marea;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblMaintenancearea Update(TblMaintenancearea marea)
        //{
        //    try
        //    {
        //        Repository<TblMaintenancearea>.Instance.Update(marea);
        //        if (Repository<TblMaintenancearea>.Instance.SaveChanges() > 0)
        //            return marea;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblMaintenancearea Delete(string mareacode)
        //{
        //    try
        //    {
        //        var ccode = Repository<TblMaintenancearea>.Instance.GetSingleOrDefault(x => x.Code == mareacode);
        //        Repository<TblMaintenancearea>.Instance.Remove(ccode);
        //        if (Repository<TblMaintenancearea>.Instance.SaveChanges() > 0)
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

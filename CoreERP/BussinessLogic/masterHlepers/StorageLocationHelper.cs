using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class StorageLocationHelper
    {
        //public static IEnumerable<TblStorageLocation> GetList(string stloc)
        //{
        //    try
        //    {
        //        return Repository<TblStorageLocation>.Instance.Where(x => x.Code == stloc);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblStorageLocation> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblStorageLocation>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        //public static TblStorageLocation Register(TblStorageLocation stloc)
        //{
        //    try
        //    {
        //        Repository<TblStorageLocation>.Instance.Add(stloc);
        //        if (Repository<TblStorageLocation>.Instance.SaveChanges() > 0)
        //            return stloc;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblStorageLocation Update(TblStorageLocation stloc)
        //{
        //    try
        //    {
        //        Repository<TblStorageLocation>.Instance.Update(stloc);
        //        if (Repository<TblStorageLocation>.Instance.SaveChanges() > 0)
        //            return stloc;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblStorageLocation Delete(string stloccode)
        //{
        //    try
        //    {
        //        var ccode = Repository<TblStorageLocation>.Instance.GetSingleOrDefault(x => x.Code == stloccode);
        //        Repository<TblStorageLocation>.Instance.Remove(ccode);
        //        if (Repository<TblStorageLocation>.Instance.SaveChanges() > 0)
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

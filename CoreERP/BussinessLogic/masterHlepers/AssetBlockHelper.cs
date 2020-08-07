using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class AssetBlockHelper
    {
        //public static IEnumerable<TblAssetBlock> GetList(string code)
        //{
        //    try
        //    {
        //        return Repository<TblAssetBlock>.Instance.Where(x => x.Code == code);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblAssetBlock> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblAssetBlock>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        //public static TblAssetBlock Register(TblAssetBlock assetblock)
        //{
        //    try
        //    {
        //        Repository<TblAssetBlock>.Instance.Add(assetblock);
        //        if (Repository<TblAssetBlock>.Instance.SaveChanges() > 0)
        //            return assetblock;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblAssetBlock Update(TblAssetBlock assetblock)
        //{
        //    try
        //    {
        //        Repository<TblAssetBlock>.Instance.Update(assetblock);
        //        if (Repository<TblAssetBlock>.Instance.SaveChanges() > 0)
        //            return assetblock;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblAssetBlock Delete(string codes)
        //{
        //    try
        //    {

        //        var rcode = Repository<TblAssetBlock>.Instance.GetSingleOrDefault(x => x.Code == codes);
        //        Repository<TblAssetBlock>.Instance.Remove(rcode);
        //        if (Repository<TblAssetBlock>.Instance.SaveChanges() > 0)
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

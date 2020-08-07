using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class AssetClassHelper
    {
        public static IEnumerable<TblAssetClass> GetList(string code)
        {
            try
            {
                return Repository<TblAssetClass>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssetClass> GetList()
        {
            try
            {
                return Repository<TblAssetClass>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblAssetClass Register(TblAssetClass assetclass)
        {
            try
            {
                Repository<TblAssetClass>.Instance.Add(assetclass);
                if (Repository<TblAssetClass>.Instance.SaveChanges() > 0)
                    return assetclass;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAssetClass Update(TblAssetClass dparea)
        {
            try
            {
                Repository<TblAssetClass>.Instance.Update(dparea);
                if (Repository<TblAssetClass>.Instance.SaveChanges() > 0)
                    return dparea;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAssetClass Delete(string codes)
        {
            try
            {

                var rcode = Repository<TblAssetClass>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<TblAssetClass>.Instance.Remove(rcode);
                if (Repository<TblAssetClass>.Instance.SaveChanges() > 0)
                    return rcode;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

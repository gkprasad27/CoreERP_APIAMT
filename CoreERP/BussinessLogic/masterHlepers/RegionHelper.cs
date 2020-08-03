using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class RegionHelper
    {
        public static IEnumerable<TblRegion> GetList(string region)
        {
            try
            {
                return Repository<TblRegion>.Instance.Where(x => x.RegionCode == region);
            }
            catch { throw; }
        }

        public static IEnumerable<TblRegion> GetList()
        {
            try
            {
                return Repository<TblRegion>.Instance.GetAll().OrderBy(x => x.RegionCode);
            }
            catch { throw; }
        }

        public static TblRegion Register(TblRegion region)
        {
            try
            {
                Repository<TblRegion>.Instance.Add(region);
                if (Repository<TblRegion>.Instance.SaveChanges() > 0)
                    return region;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblRegion Update(TblRegion region)
        {
            try
            {
                Repository<TblRegion>.Instance.Update(region);
                if (Repository<TblRegion>.Instance.SaveChanges() > 0)
                    return region;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblRegion Delete(string rcodes)
        {
            try
            {
                var code = Repository<TblRegion>.Instance.GetSingleOrDefault(x => x.RegionCode == rcodes);
                Repository<TblRegion>.Instance.Remove(code);
                if (Repository<TblRegion>.Instance.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

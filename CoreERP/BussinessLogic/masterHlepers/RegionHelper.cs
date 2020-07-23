using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class RegionHelper
    {
        public static List<TblRegion> GetList(string region)
        {
            try
            {
                using Repository<TblRegion> repo = new Repository<TblRegion>();
                return repo.TblRegion.Where(x => x.RegionCode == region).ToList();
            }
            catch { throw; }
        }

        public static List<TblRegion> GetList()
        {
            try
            {
                using Repository<TblRegion> repo = new Repository<TblRegion>();
                return repo.TblRegion.ToList();
            }
            catch { throw; }
        }

        public static TblRegion Register(TblRegion region)
        {
            try
            {
                using Repository<TblRegion> repo = new Repository<TblRegion>();
                repo.TblRegion.Add(region);
                if (repo.SaveChanges() > 0)
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
                using Repository<TblRegion> repo = new Repository<TblRegion>();
                repo.TblRegion.Update(region);
                if (repo.SaveChanges() > 0)
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
                using Repository<TblRegion> repo = new Repository<TblRegion>();
                var rcode = repo.TblRegion.Where(x => x.RegionCode == rcodes).FirstOrDefault();
                repo.TblRegion.Remove(rcode);
                if (repo.SaveChanges() > 0)
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

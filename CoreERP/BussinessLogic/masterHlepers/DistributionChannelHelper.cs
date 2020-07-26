using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class DistributionChannelHelper
    {
        public static List<TblDistributionChannel> GetList(string dbchanel)
        {
            try
            {
                using Repository<TblDistributionChannel> repo = new Repository<TblDistributionChannel>();
                return repo.TblDistributionChannel.Where(x => x.Code == dbchanel).ToList();
            }
            catch { throw; }
        }

        public static List<TblDistributionChannel> GetList()
        {
            try
            {
                using Repository<TblDistributionChannel> repo = new Repository<TblDistributionChannel>();
                return repo.TblDistributionChannel.ToList();
            }
            catch { throw; }
        }

        public static TblDistributionChannel Register(TblDistributionChannel dbchanel)
        {
            try
            {
                using Repository<TblDistributionChannel> repo = new Repository<TblDistributionChannel>();
                repo.TblDistributionChannel.Add(dbchanel);
                if (repo.SaveChanges() > 0)
                    return dbchanel;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblDistributionChannel Update(TblDistributionChannel dbchanel)
        {
            try
            {
                using Repository<TblDistributionChannel> repo = new Repository<TblDistributionChannel>();
                repo.TblDistributionChannel.Update(dbchanel);
                if (repo.SaveChanges() > 0)
                    return dbchanel;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblDistributionChannel Delete(string dccode)
        {
            try
            {
                using Repository<TblDistributionChannel> repo = new Repository<TblDistributionChannel>();
                var dccodes = repo.TblDistributionChannel.Where(x => x.Code == dccode).FirstOrDefault();
                repo.TblDistributionChannel.Remove(dccodes);
                if (repo.SaveChanges() > 0)
                    return dccodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

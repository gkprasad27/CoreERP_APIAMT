using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class DistributionChannelHelper
    {
        public static IEnumerable<TblDistributionChannel> GetList(string dbchanel)
        {
            try
            {
                return Repository<TblDistributionChannel>.Instance.Where(x => x.Code == dbchanel);
            }
            catch { throw; }
        }

        public static IEnumerable<TblDistributionChannel> GetList()
        {
            try
            {
                return Repository<TblDistributionChannel>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblDistributionChannel Register(TblDistributionChannel dbchanel)
        {
            try
            {
                Repository<TblDistributionChannel>.Instance.Add(dbchanel);
                if (Repository<TblDistributionChannel>.Instance.SaveChanges() > 0)
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
                Repository<TblDistributionChannel>.Instance.Update(dbchanel);
                if (Repository<TblDistributionChannel>.Instance.SaveChanges() > 0)
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
                var ccode = Repository<TblDistributionChannel>.Instance.GetSingleOrDefault(x => x.Code == dccode);
                Repository<TblDistributionChannel>.Instance.Remove(ccode);
                if (Repository<TblDistributionChannel>.Instance.SaveChanges() > 0)
                    return ccode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

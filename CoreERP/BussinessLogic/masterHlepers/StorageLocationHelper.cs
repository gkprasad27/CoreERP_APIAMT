using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class StorageLocationHelper
    {
        public static List<TblStorageLocation> GetList(string stloc)
        {
            try
            {
                using Repository<TblStorageLocation> repo = new Repository<TblStorageLocation>();
                return repo.TblStorageLocation.Where(x => x.Code == stloc).ToList();
            }
            catch { throw; }
        }

        public static List<TblStorageLocation> GetList()
        {
            try
            {
                using Repository<TblStorageLocation> repo = new Repository<TblStorageLocation>();
                return repo.TblStorageLocation.ToList();
            }
            catch { throw; }
        }

        public static TblStorageLocation Register(TblStorageLocation stloc)
        {
            try
            {
                using Repository<TblStorageLocation> repo = new Repository<TblStorageLocation>();
                repo.TblStorageLocation.Add(stloc);
                if (repo.SaveChanges() > 0)
                    return stloc;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblStorageLocation Update(TblStorageLocation stloc)
        {
            try
            {
                using Repository<TblStorageLocation> repo = new Repository<TblStorageLocation>();
                repo.TblStorageLocation.Update(stloc);
                if (repo.SaveChanges() > 0)
                    return stloc;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblStorageLocation Delete(string stloccode)
        {
            try
            {
                using Repository<TblStorageLocation> repo = new Repository<TblStorageLocation>();
                var stloccodes = repo.TblStorageLocation.Where(x => x.Code == stloccode).FirstOrDefault();
                repo.TblStorageLocation.Remove(stloccodes);
                if (repo.SaveChanges() > 0)
                    return stloccodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class LocationHelper
    {
        public static List<TblLocation> GetList(string locid)
        {
            try
            {
                using Repository<TblLocation> repo = new Repository<TblLocation>();
                return repo.TblLocation.Where(x => x.LocationId == locid).ToList();
            }
            catch { throw; }
        }

        public static List<TblPlant> GetPlants()
        {
            try
            {
                using Repository<TblPlant> repo = new Repository<TblPlant>();
                return repo.TblPlant.ToList();
            }
            catch { throw; }
        }
        public static List<TblLocation> GetList()
        {
            try
            {
                using Repository<TblLocation> repo = new Repository<TblLocation>();
                return repo.TblLocation.ToList();
            }
            catch { throw; }
        }

        public static TblLocation Register(TblLocation loc)
        {
            try
            {
                using Repository<TblLocation> repo = new Repository<TblLocation>();
                repo.TblLocation.Add(loc);
                if (repo.SaveChanges() > 0)
                    return loc;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblLocation Update(TblLocation loc)
        {
            try
            {
                using Repository<TblLocation> repo = new Repository<TblLocation>();
                repo.TblLocation.Update(loc);
                if (repo.SaveChanges() > 0)
                    return loc;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblLocation Delete(string loccode)
        {
            try
            {
                using Repository<TblLocation> repo = new Repository<TblLocation>();
                var lcode = repo.TblLocation.Where(x => x.LocationId == loccode).FirstOrDefault();
                repo.TblLocation.Remove(lcode);
                if (repo.SaveChanges() > 0)
                    return lcode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

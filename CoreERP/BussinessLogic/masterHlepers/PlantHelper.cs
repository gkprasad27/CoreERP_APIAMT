using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class PlantHelper
    {
        public static List<TblPlant> GetList(string plant)
        {
            try
            {
                using Repository<TblPlant> repo = new Repository<TblPlant>();
                return repo.TblPlant.Where(x => x.PlantCode == plant).ToList();
            }
            catch { throw; }
        }

        public static List<TblPlant> GetList()
        {
            try
            {
                using Repository<TblPlant> repo = new Repository<TblPlant>();
                return repo.TblPlant.ToList();
            }
            catch { throw; }
        }

        public static TblPlant Register(TblPlant plant)
        {
            try
            {
                using Repository<TblPlant> repo = new Repository<TblPlant>();
                repo.TblPlant.Add(plant);
                if (repo.SaveChanges() > 0)
                    return plant;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblPlant Update(TblPlant plant)
        {
            try
            {
                using Repository<TblPlant> repo = new Repository<TblPlant>();
                repo.TblPlant.Update(plant);
                if (repo.SaveChanges() > 0)
                    return plant;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblPlant Delete(string code)
        {
            try
            {
                using Repository<TblPlant> repo = new Repository<TblPlant>();
                var plantcodes = repo.TblPlant.Where(x => x.PlantCode == code).FirstOrDefault();
                repo.TblPlant.Remove(plantcodes);
                if (repo.SaveChanges() > 0)
                    return plantcodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

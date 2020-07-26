using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class MaintenanceAreaHelper
    {
        public static List<TblMaintenancearea> GetList(string marea)
        {
            try
            {
                using Repository<TblMaintenancearea> repo = new Repository<TblMaintenancearea>();
                return repo.TblMaintenancearea.Where(x => x.Code == marea).ToList();
            }
            catch { throw; }
        }

        public static List<TblMaintenancearea> GetList()
        {
            try
            {
                using Repository<TblMaintenancearea> repo = new Repository<TblMaintenancearea>();
                return repo.TblMaintenancearea.ToList();
            }
            catch { throw; }
        }

        public static TblMaintenancearea Register(TblMaintenancearea marea)
        {
            try
            {
                using Repository<TblMaintenancearea> repo = new Repository<TblMaintenancearea>();
                repo.TblMaintenancearea.Add(marea);
                if (repo.SaveChanges() > 0)
                    return marea;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblMaintenancearea Update(TblMaintenancearea marea)
        {
            try
            {
                using Repository<TblMaintenancearea> repo = new Repository<TblMaintenancearea>();
                repo.TblMaintenancearea.Update(marea);
                if (repo.SaveChanges() > 0)
                    return marea;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblMaintenancearea Delete(string mareacode)
        {
            try
            {
                using Repository<TblMaintenancearea> repo = new Repository<TblMaintenancearea>();
                var mareacodes = repo.TblMaintenancearea.Where(x => x.Code == mareacode).FirstOrDefault();
                repo.TblMaintenancearea.Remove(mareacodes);
                if (repo.SaveChanges() > 0)
                    return mareacodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

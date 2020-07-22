using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class DesignationHelper
    {
        public static List<TblDesignation> GetList(string desigcode)
        {
            try
            {
                using Repository<TblDesignation> repo = new Repository<TblDesignation>();
                return repo.TblDesignation.Where(x => x.DesignationName == desigcode).ToList();
                //return null;
            }
            catch { throw; }
        }

        public static List<TblDesignation> GetList()
        {
            try
            {
                using Repository<TblDesignation> repo = new Repository<TblDesignation>();
                return repo.TblDesignation.ToList();
                //return null;
            }
            catch { throw; }
        }

        public static TblDesignation Register(TblDesignation designation)
        {
            try
            {
                using Repository<TblDesignation> repo = new Repository<TblDesignation>();
                repo.TblDesignation.Add(designation);
                if (repo.SaveChanges() > 0)
                    return designation;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblDesignation Update(TblDesignation designation)
        {
            try
            {
                using Repository<TblDesignation> repo = new Repository<TblDesignation>();
                repo.TblDesignation.Update(designation);
                if (repo.SaveChanges() > 0)
                    return designation;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblDesignation Delete(string desigCode)
        {
            try
            {
                using Repository<TblDesignation> repo = new Repository<TblDesignation>();
                var designation = repo.TblDesignation.Where(x => x.DesignationId == Convert.ToDecimal(desigCode)).FirstOrDefault();
                repo.TblDesignation.Remove(designation);
                if (repo.SaveChanges() > 0)
                    return designation;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

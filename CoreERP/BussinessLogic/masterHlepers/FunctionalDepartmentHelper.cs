using System;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class FunctionalDepartmentHelper
    {
        public static List<TblFunctionalDepartment> GetList(string fdept)
        {
            try
            {
                using Repository<TblFunctionalDepartment> repo = new Repository<TblFunctionalDepartment>();
                return repo.TblFunctionalDepartment.Where(x => x.Code == fdept).ToList();
            }
            catch { throw; }
        }

        public static List<TblFunctionalDepartment> GetList()
        {
            try
            {
                using Repository<TblFunctionalDepartment> repo = new Repository<TblFunctionalDepartment>();
                return repo.TblFunctionalDepartment.ToList();
            }
            catch { throw; }
        }

        public static TblFunctionalDepartment Register(TblFunctionalDepartment fdept)
        {
            try
            {
                using Repository<TblFunctionalDepartment> repo = new Repository<TblFunctionalDepartment>();
                repo.TblFunctionalDepartment.Add(fdept);
                if (repo.SaveChanges() > 0)
                    return fdept;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblFunctionalDepartment Update(TblFunctionalDepartment fdept)
        {
            try
            {
                using Repository<TblFunctionalDepartment> repo = new Repository<TblFunctionalDepartment>();
                repo.TblFunctionalDepartment.Update(fdept);
                if (repo.SaveChanges() > 0)
                    return fdept;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblFunctionalDepartment Delete(string code)
        {
            try
            {
                using Repository<TblFunctionalDepartment> repo = new Repository<TblFunctionalDepartment>();
                var fdcodes = repo.TblFunctionalDepartment.Where(x => x.Code == code).FirstOrDefault();
                repo.TblFunctionalDepartment.Remove(fdcodes);
                if (repo.SaveChanges() > 0)
                    return fdcodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

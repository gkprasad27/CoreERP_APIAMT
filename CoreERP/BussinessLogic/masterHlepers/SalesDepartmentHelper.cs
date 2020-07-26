using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class SalesDepartmentHelper
    {
        public static List<SalesDepartment> GetList(string sdept)
        {
            try
            {
                using Repository<SalesDepartment> repo = new Repository<SalesDepartment>();
                return repo.SalesDepartment.Where(x => x.DepartmentCode == sdept).ToList();
            }
            catch { throw; }
        }

        public static List<SalesDepartment> GetList()
        {
            try
            {
                using Repository<SalesDepartment> repo = new Repository<SalesDepartment>();
                return repo.SalesDepartment.ToList();
            }
            catch { throw; }
        }

        public static SalesDepartment Register(SalesDepartment sdept)
        {
            try
            {
                using Repository<SalesDepartment> repo = new Repository<SalesDepartment>();
                repo.SalesDepartment.Add(sdept);
                if (repo.SaveChanges() > 0)
                    return sdept;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SalesDepartment Update(SalesDepartment sdept)
        {
            try
            {
                using Repository<SalesDepartment> repo = new Repository<SalesDepartment>();
                repo.SalesDepartment.Update(sdept);
                if (repo.SaveChanges() > 0)
                    return sdept;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SalesDepartment Delete(string code)
        {
            try
            {
                using Repository<SalesDepartment> repo = new Repository<SalesDepartment>();
                var scodes = repo.SalesDepartment.Where(x => x.DepartmentCode == code).FirstOrDefault();
                repo.SalesDepartment.Remove(scodes);
                if (repo.SaveChanges() > 0)
                    return scodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class SalesDepartmentHelper
    {
        public static IEnumerable<SalesDepartment> GetList(string sdept)
        {
            try
            {
                return Repository<SalesDepartment>.Instance.Where(x => x.DepartmentCode == sdept);

            }
            catch { throw; }
        }

        public static IEnumerable<SalesDepartment> GetList()
        {
            try
            {
                return Repository<SalesDepartment>.Instance.GetAll().OrderBy(x => x.DepartmentCode);
            }
            catch { throw; }
        }

        public static SalesDepartment Register(SalesDepartment sdept)
        {
            try
            {
                Repository<SalesDepartment>.Instance.Add(sdept);
                if (Repository<SalesDepartment>.Instance.SaveChanges() > 0)
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
                Repository<SalesDepartment>.Instance.Update(sdept);
                if (Repository<SalesDepartment>.Instance.SaveChanges() > 0)
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
                var ccode = Repository<SalesDepartment>.Instance.GetSingleOrDefault(x => x.DepartmentCode == code);
                Repository<SalesDepartment>.Instance.Remove(ccode);
                if (Repository<SalesDepartment>.Instance.SaveChanges() > 0)
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

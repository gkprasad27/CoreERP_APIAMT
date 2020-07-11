using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class DepartmentHelper
    {
        public static List<Department> GetList(string divisionCode)
        {
            try
            {
                using Repository<Department> repo = new Repository<Department>();
                return repo.Department.Where(x => x.DepartmentName == divisionCode).ToList();

                //return null;
            }
            catch { throw; }
        }

        public static List<Department> GetList()
        {
            try
            {
                using Repository<Department> repo = new Repository<Department>();
                return repo.Department.ToList();
                //return null;
            }
            catch { throw; }
        }

        public static Department Register(Department dept)
        {
            try
            {
                using Repository<Department> repo = new Repository<Department>();
                repo.Department.Add(dept);
                if (repo.SaveChanges() > 0)
                    return dept;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Department Update(Department dept)
        {
            try
            {
                using Repository<Department> repo = new Repository<Department>();
                repo.Department.Update(dept);
                if (repo.SaveChanges() > 0)
                    return dept;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Department Delete(string deptcode)
        {
            try
            {
                using Repository<Department> repo = new Repository<Department>();
                var dept = repo.Department.Where(x => x.DepartmentId == deptcode).FirstOrDefault();
                //dept.IsActive = "N";
                repo.Department.Remove(dept);
                if (repo.SaveChanges() > 0)
                    return dept;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

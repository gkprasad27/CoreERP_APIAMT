using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class EmployeeHelper
    {

        public static List<TblEmployee> GetEmployes()
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                return repo.TblEmployee.ToList();
            }
            catch { throw; }
        }

        public static List<TblEmployee> GetEmployesByID(string empCode)
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                return repo.TblEmployee.AsEnumerable().Where(x => x.EmployeeCode == empCode).Select(x => x).ToList();
            }
            catch { throw; }
        }

        public static List<TblEmployee> GetEmployesByName(string name)
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                return repo.TblEmployee.Where(x => x.EmployeeName.ToLower() == name.ToLower()).Select(x => x).ToList();
            }
            catch { throw; }
        }


        public static TblEmployee Register(TblEmployee employees)
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                employees.IsActive = true;
                repo.TblEmployee.Add(employees);
                if (repo.SaveChanges() > 0)
                    return employees;

                return null;
            }
            catch { throw; }
        }


        public static TblEmployee Update(TblEmployee employees)
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                repo.TblEmployee.Update(employees);
                if (repo.SaveChanges() > 0)
                    return employees;

                return null;
            }
            catch { throw; }
        }


        public static TblEmployee Delete(string empCode)
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                var emp = repo.TblEmployee.Where(e => e.EmployeeId == Convert.ToDecimal(empCode)).FirstOrDefault();
                emp.IsActive = false;
                repo.TblEmployee.Update(emp);
                if (repo.SaveChanges() > 0)
                    return emp;

                return null;
            }
            catch { throw; }
        }


        #region Employee In Branch
        public static List<EmployeeInBranches> GetEmployeeInBranches(string empCode = null, string branchCode = null)
        {
            try
            {
                using Repository<EmployeeInBranches> repo = new Repository<EmployeeInBranches>();
                return repo.EmployeeInBranches.AsEnumerable()
.Where(x => x.EmpCode == (empCode ?? x.EmpCode)
&& x.BranchCode == (branchCode ?? x.BranchCode)
&& x.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
).ToList();
                //return null;
            }
            catch { throw; }
        }


        public static EmployeeInBranches RegisterEmployeeInBranch(EmployeeInBranches empbr)
        {
            try
            {
                using Repository<EmployeeInBranches> repo = new Repository<EmployeeInBranches>();
                empbr.Active = "Y";
                empbr.AddDate = DateTime.Now;
                repo.EmployeeInBranches.Add(empbr);
                if (repo.SaveChanges() > 0)
                    return empbr;

                return null;
            }
            catch { throw; }
        }


        public static EmployeeInBranches UpdateEmployeeInBranches(EmployeeInBranches empbr)
        {
            try
            {
                using Repository<EmployeeInBranches> repo = new Repository<EmployeeInBranches>();
                repo.EmployeeInBranches.Update(empbr);
                if (repo.SaveChanges() > 0)
                    return empbr;

                return null;
            }
            catch { throw; }
        }


        public static EmployeeInBranches DeleteEmployeeInBranches(string empCode)
        {
            try
            {
                using Repository<EmployeeInBranches> repo = new Repository<EmployeeInBranches>();
                var emp = repo.EmployeeInBranches.Where(e => e.SeqId == Convert.ToInt32(empCode)).FirstOrDefault();
                emp.Active = "N";
                repo.EmployeeInBranches.Remove(emp);
                if (repo.SaveChanges() > 0)
                    return emp;

                return null;
            }
            catch { throw; }
        }
        #endregion
    }
}

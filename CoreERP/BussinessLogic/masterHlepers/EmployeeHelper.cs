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
      
        public static List<Employees> GetEmployes()
        {
            try
            {
                using Repository<Employees> repo = new Repository<Employees>();
                return repo.Employees.Where(x => x.Active == "Y").ToList();
            }
            catch { throw; }
        }

        public static List<Employees> GetEmployesByID(string empCode)
        {
            try
            {
                using Repository<Employees> repo = new Repository<Employees>();
                return repo.Employees.AsEnumerable()
.Where(x => x.Code == empCode && x.Active.Equals("Y", StringComparison.OrdinalIgnoreCase))
.Select(x => x).ToList();
            }
            catch { throw; }
        }

        public static List<Employees> GetEmployesByName(string name)
        {
            try
            {
                using Repository<Employees> repo = new Repository<Employees>();
                return repo.Employees
.Where(x => x.Name.ToLower() == name.ToLower())
.Select(x => x).ToList();
            }
            catch { throw; }
        }


        public static Employees Register(Employees employees)
        {
            try
            {
                using Repository<Employees> repo = new Repository<Employees>();
                employees.Active = "Y";
                repo.Employees.Add(employees);
                if (repo.SaveChanges() > 0)
                    return employees;

                return null;
            }
            catch { throw; }
        }


        public static Employees Update(Employees employees)
        {
            try
            {
                using Repository<Employees> repo = new Repository<Employees>();
                repo.Employees.Update(employees);
                if (repo.SaveChanges() > 0)
                    return employees;

                return null;
            }
            catch { throw; }
        }


        public static Employees Delete(string empCode)
        {
            try
            {
                using Repository<Employees> repo = new Repository<Employees>();
                var emp = repo.Employees.Where(e => e.Code == empCode).FirstOrDefault();
                emp.Active = "N";
                repo.Employees.Update(emp);
                if (repo.SaveChanges() > 0)
                    return emp;

                return null;
            }
            catch { throw; }
        }


        #region Employee In Branch
        public static List<EmployeeInBranches> GetEmployeeInBranches(string empCode=null,string branchCode=null)
        {
            try
            {
                using Repository<EmployeeInBranches> repo = new Repository<EmployeeInBranches>();
                return repo.EmployeeInBranches.AsEnumerable()
.Where(x => x.EmpCode == (empCode ?? x.EmpCode)
&& x.BranchCode == (branchCode ?? x.BranchCode)
&& x.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
).ToList();
            }
            catch { throw; }
        }

      
        public static EmployeeInBranches RegisterEmployeeInBranch(EmployeeInBranches empbr)
        {
            try
            {
                using Repository<EmployeeInBranches> repo = new Repository<EmployeeInBranches>();
                empbr.Active = "Y";

                var lastrecord = repo.EmployeeInBranches.Select(x => x).OrderByDescending(emp => emp.Ext1).FirstOrDefault();
                if (lastrecord != null)
                {
                    empbr.Ext1 = (int.Parse(lastrecord.Ext1) + 1).ToString();
                }
                else
                {
                    empbr.Ext1 = "1";
                }

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
                var emp = repo.EmployeeInBranches.Where(e => e.EmpCode == empCode).FirstOrDefault();
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

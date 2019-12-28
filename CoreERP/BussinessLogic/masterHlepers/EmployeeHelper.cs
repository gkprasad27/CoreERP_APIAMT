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
        private static Repository<Employees> _repo = null;
        private static Repository<Employees> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Employees>();
                return _repo;
            }
        }


        public static List<Employees> GetEmployes()
        {
            try
            {
                return repo.Employees.Select(x => x).ToList();
            }
            catch { throw; }
        }

        public static List<Employees> GetEmployesByID(string empCode)
        {
            try
            {
              return  repo.Employees
                    .Where(x=> x.Code == empCode)
                    .Select(x => x).ToList();
            }
            catch { throw; }
        }

        public static List<Employees> GetEmployesByName(string name)
        {
            try
            {
             return   repo.Employees
                   .Where(x => x.Name.ToLower() == name.ToLower())
                   .Select(x => x).ToList();
            }
            catch { throw; }
        }


        public static int Register(Employees employees)
        {
            try
            {
                repo.Employees.Add(employees);
                return repo.SaveChanges();
            }
            catch { throw; }
        }


        public static int Update(Employees employees)
        {
            try
            {
                repo.Employees.Update(employees);
                return repo.SaveChanges();
            }
            catch { throw; }
        }


        public static int Delete(string empCode)
        {
            try
            {
                var emp = repo.Employees.Where(e => e.Code == empCode).FirstOrDefault();
                repo.Employees.Remove(emp);
                return repo.SaveChanges();
            }
            catch { throw; }
        }


        #region Employee In Branch
        public static List<EmployeeInBranches> GetEmployeeInBranches(string empCode=null,string branchCode=null)
        {
            try
            {
                return repo.EmployeeInBranches
                           .Where(x => x.EmpCode == (empCode ?? x.EmpCode)
                                    && x.BranchCode == (branchCode?? x.BranchCode)
                           ).ToList();
            }
            catch { throw; }
        }

      
        public static int RegisterEmployeeInBranch(EmployeeInBranches empbr)
        {
            try
            {
                var lastrecord = repo.EmployeeInBranches.Select(x=> x).OrderByDescending(emp => emp.Ext1).FirstOrDefault();
                if (lastrecord != null)
                {
                    empbr.Ext1 = (int.Parse(lastrecord.Ext1) + 1).ToString();
                }
                else
                {
                    empbr.Ext1 = "1";
                }

                repo.EmployeeInBranches.Add(empbr);
                return repo.SaveChanges();
            }
            catch { throw; }
        }


        public static int UpdateEmployeeInBranches(EmployeeInBranches empbr)
        {
            try
            {
                repo.EmployeeInBranches.Update(empbr);
                return repo.SaveChanges();
            }
            catch { throw; }
        }


        public static int DeleteEmployeeInBranches(string empCode)
        {
            try
            {
                var emp = repo.EmployeeInBranches.Where(e => e.EmpCode == empCode).FirstOrDefault();
                repo.EmployeeInBranches.Remove(emp);
                return repo.SaveChanges();
            }
            catch { throw; }
        }
        #endregion
    }
}

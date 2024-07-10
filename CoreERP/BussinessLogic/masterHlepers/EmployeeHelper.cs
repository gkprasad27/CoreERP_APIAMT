using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class EmployeeHelper
    {

        public static IEnumerable<TblEmployee> GetEmployes()
        {
            try
            {
                return Repository<TblEmployee>.Instance.GetAll().OrderBy(x => x.EmployeeCode);
            }
            catch { throw; }
        }

        public static IEnumerable<TblEmployee> GetEmployesByID(string empCode)
        {
            try
            {
                return Repository<TblEmployee>.Instance.Where(x => x.EmployeeCode == empCode);
            }
            catch { throw; }
        }

        public static IEnumerable<TblEmployee> GetEmployesByName(string name)
        {
            try
            {
                return Repository<TblEmployee>.Instance.Where(x => x.EmployeeName == name);
            }
            catch { throw; }
        }

        public static IEnumerable<TblEmployee> GetEmployeesByCompany(string company)
        {
            try
            {
                //return Repository<TblEmployee>.Instance.Where(x => x.CompanyCode == company && x.IsActive==true);
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                var emp = repo.TblEmployee.Where(e => e.CompanyCode == company && e.IsActive == true).ToList();
                return emp;
            }
            catch { throw; }
        }

        public static TblEmployee Register(TblEmployee employees)
        {
            try
            {

                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                employees.IsActive = true;
                repo.Add(employees);

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
                repo.Update(employees);
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
                var emp = repo.TblEmployee.Where(e => e.EmployeeCode == empCode).FirstOrDefault();
                emp.IsActive = false;
                repo.TblEmployee.Update(emp);
                if (repo.SaveChanges() > 0)
                    return emp;

                return null;
            }
            catch { throw; }
        }


        #region Employee In Branch
        public static IEnumerable<EmployeeInBranches> GetEmployeeInBranches(string empCode = null, string branchCode = null)
        {
            try
            {

                return Repository<EmployeeInBranches>.Instance.Where(x => x.EmpCode == (empCode ?? x.EmpCode)
                                                        && x.BranchCode == (branchCode ?? x.BranchCode)
                                                        && x.Active.Equals("Y", StringComparison.OrdinalIgnoreCase));

               
            }
            catch { throw; }
        }
        #endregion

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
//#endregion
    }
}

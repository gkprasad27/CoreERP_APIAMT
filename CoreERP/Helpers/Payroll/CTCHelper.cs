using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoreERP.BussinessLogic.Payroll
{
    public class CTCHelper
    {
        public static List<Ctcbreakup> GetListOfCTCs()
        {
            try
            {
                //using Repository<Ctcbreakup> repo = new Repository<Ctcbreakup>();
                //return repo.Ctcbreakup.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();

                return null;
            }
            catch { throw; }
        }

        public static Ctcbreakup GetCTCs(string compCode)
        {
            try
            {
                //                using Repository<Ctcbreakup> repo = new Repository<Ctcbreakup>();
                //                return repo.Ctcbreakup.AsEnumerable()
                //.Where(x => x.CompanyCode.Equals(compCode))
                //.FirstOrDefault();
                return null;
            }
            catch { throw; }
        }

        public List<TblEmployee> GetEmployeesList(string empCode = null)
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                return repo.TblEmployee.Where(emp => emp.EmployeeCode.Contains(empCode ?? emp.EmployeeCode)).OrderBy(x => x.EmployeeCode).ToList();

            }
            catch (Exception ex) { throw ex; }
        }

        public static Ctcbreakup Register(Ctcbreakup ctcBreakup)
        {
            try
            {
                //using Repository<Ctcbreakup> repo = new Repository<Ctcbreakup>();
                //ctcBreakup.Active = "Y";
                //repo.Ctcbreakup.Add(ctcBreakup);
                //if (repo.SaveChanges() > 0)
                //    return ctcBreakup;

                return null;
            }
            catch { throw; }
        }

        public static Ctcbreakup Update(Ctcbreakup ctcBreakup)
        {
            try
            {
                //using Repository<Ctcbreakup> repo = new Repository<Ctcbreakup>();
                //repo.Ctcbreakup.Update(ctcBreakup);
                //if (repo.SaveChanges() > 0)
                //    return ctcBreakup;

                return null;
            }
            catch { throw; }
        }


        public static List<ComponentMaster> GetComponentList()
        {
            try
            {
                //using Repository<ComponentMaster> repo = new Repository<ComponentMaster>();
                //return repo.ComponentMaster.AsEnumerable().Where(m => m.Active == "Y").ToList();
                return null;
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<StructureCreation> GetStructureList()
        {
            try
            {
                //using Repository<StructureCreation> repo = new Repository<StructureCreation>();
                //return repo.StructureCreation.AsEnumerable().Where(m => m.Active == "Y").ToList();

                return null;
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<PayrollCycle> GetPayrollCycleList()
        {
            try
            {
                //using Repository<PayrollCycle> repo = new Repository<PayrollCycle>();
                //return repo.PayrollCycle.AsEnumerable().Where(m => m.Active == "Y").ToList();

                return null;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}

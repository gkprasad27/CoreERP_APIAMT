using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoreERP.BussinessLogic.Payroll
{
    public class PayrollCycleHelper
    {
        public static List<PayrollCycle> GetListOfPayrollCycles()
        {
            try
            {
                using (Repository<PayrollCycle> repo = new Repository<PayrollCycle>())
                {
                    return repo.PayrollCycle.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }

        //public static List<Department> GetDepartmentsList()
        //{
        //    try
        //    {
        //        using (Repository<Department> repo = new Repository<Department>())
        //        {
        //            return repo.Department.AsEnumerable().Where(m => m.Active == "Y").ToList();
        //        }
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        public static PayrollCycle GetPayrollCycle(string Payrollcycle)
        {
            try
            {
                using (Repository<PayrollCycle> repo = new Repository<PayrollCycle>())
                {
                    return repo.PayrollCycle.AsEnumerable()
                               .Where(x => x.CycleName.Equals(Payrollcycle))
                                         .FirstOrDefault();
                }
            }
            catch { throw; }
        }

        public static PayrollCycle Register(PayrollCycle payrollCycle)
        {
            try
            {
                using (Repository<PayrollCycle> repo = new Repository<PayrollCycle>())
                {
                    payrollCycle.Active = "Y";
                    repo.PayrollCycle.Add(payrollCycle);
                    if (repo.SaveChanges() > 0)
                        return payrollCycle;

                    return null;
                }
            }
            catch { throw; }
        }

        public static PayrollCycle Update(PayrollCycle payrollCycle)
        {
            try
            {
                using (Repository<PayrollCycle> repo = new Repository<PayrollCycle>())
                {
                    repo.PayrollCycle.Update(payrollCycle);
                    if (repo.SaveChanges() > 0)
                        return payrollCycle;

                    return null;
                }
            }
            catch { throw; }
        }

        public static PayrollCycle Delete(string code)
        {
            try
            {
                using (Repository<PayrollCycle> repo = new Repository<PayrollCycle>())
                {
                    var payCycle = repo.PayrollCycle.Where(x => x.CycleName == code).FirstOrDefault();
                    payCycle.Active = "N";
                    repo.PayrollCycle.Update(payCycle);
                    if (repo.SaveChanges() > 0)
                        return payCycle;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}

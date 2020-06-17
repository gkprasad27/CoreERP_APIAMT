using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class LeaveBalancesHelper
    {
        public  List<LeaveBalanceMaster> GetLeaveOpeningBalancesList()
        {
            try
            {
                using Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>();
                return repo.LeaveBalanceMaster.ToList();

                //return null;
            }
            catch { throw; }
        }


        public  LeaveBalanceMaster Register(LeaveBalanceMaster lbm)
        {
            try
            {
                using Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>();
                repo.LeaveBalanceMaster.Add(lbm);
                if (repo.SaveChanges() > 0)
                    return lbm;

                return null;
            }
            catch { throw; }
        }

        //public  LeaveBalanceMaster Register(LeaveBalanceMaster lbm)
        //{
        //    try
        //    {
        //        using Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>();
        //         //lbm.Active = "Y";
        //        repo.LeaveBalanceMaster.Add(lbm);
        //        if (repo.SaveChanges() > 0)
        //           return lbm;

        //        //return null;
        //    }
        //    catch { throw; }
        //}

        public  List<LeaveBalanceMaster> GetList(string Code)
        {
            try
            {
                                using Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>();
                               return repo.LeaveBalanceMaster
                .Where(x => x.EmpCode == Code)
                .ToList();
                //return null;
            }
            catch { throw; }
        }
        public  LeaveBalanceMaster Update(LeaveBalanceMaster lbm)
        {
            try
            {
                using Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>();
                repo.LeaveBalanceMaster.Update(lbm);
                if (repo.SaveChanges() > 0)
                    return lbm;
                return null;
            }
            catch { throw; }
        }

        public  LeaveBalanceMaster Delete(string code)
        
        {
            try
            {
                using Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>();
                var ltype = repo.LeaveBalanceMaster.Where(x => x.EmpCode == code.ToString()).FirstOrDefault();
                repo.LeaveBalanceMaster.Remove(ltype);
                if (repo.SaveChanges() > 0)
                    return ltype;

                return null;
            }
            catch { throw; }
        }
    }
}

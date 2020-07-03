using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class LeaveBalancesHelper
    {
        public List<LeaveBalanceMaster> GetLeaveOpeningBalancesList()
        {
            try
            {
                using Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>();
                return repo.LeaveBalanceMaster.ToList();
            }
            catch { throw; }
        }
        ////Leave type assign onload to dropdown code
        public List<LeaveTypes> GetListOfleavetypes(string code, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
                {

                    var ProjectsGridData = (from pm in repo.LeaveTypes
                                                //join rm in repo.LeaveBalanceMaster on pm.LeaveCode equals rm.LeaveCode
                                            where pm.CompanyCode == code
                                            select new LeaveTypes
                                            {
                                                LeaveCode = pm.LeaveCode
                                                //+ "-" + pm.LeaveName
                                            });
                    return ProjectsGridData.ToList();
                }
            }
            catch { throw; }
        }


        public LeaveBalanceMaster Register(LeaveBalanceMaster lbm, string name, string compcode)
        {
            try
            {
                string[] stringSeparators = new string[] { "-" };
                var result = lbm.LeaveCode.Split(stringSeparators, StringSplitOptions.None);
                var code1 = result[0];
                using Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>();
                lbm.LeaveCode = code1;
                lbm.CompCode = compcode;
                lbm.Used = 0;
                lbm.UserId = name;
                lbm.TimeStamp = DateTime.Now;
                repo.LeaveBalanceMaster.Add(lbm);
                if (repo.SaveChanges() > 0)
                    return lbm;

                return null;
            }
            catch { throw; }
        }

        public List<LeaveBalanceMaster> GetList(string Code)
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
        public LeaveBalanceMaster Update(LeaveBalanceMaster lbm, string name, string compcode)
        {
            try
            {
                string[] stringSeparators = new string[] { "-" };
                var result = lbm.LeaveCode.Split(stringSeparators, StringSplitOptions.None);
                var code1 = result[0];
                using Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>();
                lbm.LeaveCode = code1;
                lbm.CompCode = compcode;
                lbm.Used = 0;
                lbm.UserId = name;
                lbm.TimeStamp = DateTime.Now;
                repo.LeaveBalanceMaster.Update(lbm);
                if (repo.SaveChanges() > 0)
                    return lbm;
                return null;
            }
            catch { throw; }
        }

        public LeaveBalanceMaster Delete(string code)

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

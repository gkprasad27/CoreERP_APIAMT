using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SelfserviceHelpers
{
    public class AdvanceHelper
    {
        public static List<TblAdvance> GetApplyAdvanceDetailsList(string code)
        {
            try
            {
                using (Repository<TblAdvance> repo = new Repository<TblAdvance>())
                {
                    if (code.ToLower() == "admin")
                    {
                        return repo.TblAdvance.ToList();

                    }
                    else
                        return repo.TblAdvance.Where(x => x.EmployeeId == code).ToList();
                }
            }
            catch { throw; }
        }

        public static TblAdvance RegisterApplyAdvancedataDetails(TblAdvance advance, LeaveBalanceMaster lbm, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                using (Repository<TblAdvance> repo = new Repository<TblAdvance>())
                {
                    var empdata = repo.TblEmployee.Where(x => x.EmployeeCode == advance.EmployeeId).FirstOrDefault();
                    advance.Status = "Applied";
                    advance.ApplyDate = DateTime.Now;
                    advance.RecommendedBy = empdata.ReportedBy;
                    //advance.ReportName = repo.TblEmployee.Where(x => x.EmployeeCode == advance.RecommendedBy).SingleOrDefault()?.EmployeeName;
                    advance.ApprovedBy = empdata.ApprovedBy;
                    //advance.ApproveName = repo.TblEmployee.Where(x => x.EmployeeCode == advance.ApprovedBy).SingleOrDefault()?.EmployeeName;
                    repo.TblAdvance.Add(advance);
                    if (repo.SaveChanges() > 0)
                        return advance;
                    return null;
                }
            }
            catch { throw; }
        }

        public static TblAdvance UpdateapplyAdvancedata(TblAdvance advance, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                //if (LeaveRequestHelper.GetList(advance.EmployeeId) == null)
                //{
                //    errorMessage = $"No leave balance record found for Employee - {nameof(advance.EmployeeId)}.";
                //    return null;
                //}

                using (Repository<TblAdvance> repo = new Repository<TblAdvance>())
                {
                    var OdAplysdata = repo.TblAdvance.Where(x => x.Id == advance.Id).FirstOrDefault();
                    if (OdAplysdata.Id > 0)
                    {
                        repo.Entry(OdAplysdata).State = EntityState.Detached;
                        advance.Status = "Applied";
                        advance.ApplyDate = DateTime.Now;
                        repo.Entry(advance).State = EntityState.Modified;
                        repo.TblAdvance.Update(advance);

                        if (repo.SaveChanges() > 0)
                            return advance;
                        else
                            errorMessage = "Registration failed.";
                        return null;
                    }

                }
                return advance;
            }

            catch { throw; }

        }

        public static List<TblAdvanceType> GetAdvanceTypes()
        {
            try
            {
                using Repository<TblAdvanceType> repo = new Repository<TblAdvanceType>();
                return repo.TblAdvanceType.ToList();
            }
            catch { throw; }
        }
    }
}

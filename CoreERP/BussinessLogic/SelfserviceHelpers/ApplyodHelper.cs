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
    public class ApplyodHelper
    {
        public static List<ApplyOddata> GetApplyodDetailsList(string code)
        {
            try
            {
                using (Repository<ApplyOddata> repo = new Repository<ApplyOddata>())
                {
                    if (code.ToLower() == "admin")
                    {
                        return repo.ApplyOddata.ToList();

                    }
                    else
                        return repo.ApplyOddata.Where(x => x.EmpCode == code).ToList();
                }
            }
            catch { throw; }
        }

        public static ApplyOddata RegisterApplyOddataDetails(ApplyOddata applyOddata, LeaveBalanceMaster lbm, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                using (Repository<ApplyOddata> repo = new Repository<ApplyOddata>())
                {
                    var empdata = repo.TblEmployee.Where(x => x.EmployeeCode == applyOddata.EmpCode).FirstOrDefault();
                    applyOddata.Status = "Applied";
                    applyOddata.ApplDate = DateTime.Now;
                    applyOddata.ReportId = empdata.ReportedBy;
                    applyOddata.ReportName = repo.TblEmployee.Where(x => x.EmployeeCode == applyOddata.ReportId).SingleOrDefault()?.EmployeeName;
                    applyOddata.ApprovedId = empdata.ApprovedBy;
                    applyOddata.ApproveName = repo.TblEmployee.Where(x => x.EmployeeCode == applyOddata.ApprovedId).SingleOrDefault()?.EmployeeName;
                    repo.ApplyOddata.Add(applyOddata);
                    if (repo.SaveChanges() > 0)
                        return applyOddata;
                    return null;
                }
            }
            catch { throw; }
        }

        public static ApplyOddata UpdateapplyOddata(ApplyOddata applyOddata, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                if (LeaveRequestHelper.GetList(applyOddata.EmpCode) == null)
                {
                    errorMessage = $"No leave balance record found for Employee - {nameof(applyOddata.EmpCode)}.";
                    return null;
                }

                using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
                {
                    //Leave_Appl_Details requisition = new Leave_Appl_Details();
                    //requisition = db.Leave_Appl_Details.Where(x => x.Sno == leaveRequest.Sno).FirstOrDefault();
                    var OdAplysdata = repo.ApplyOddata.Where(x => x.Sno == applyOddata.Sno).FirstOrDefault();
                    if (OdAplysdata.Sno > 0)
                    {
                        repo.Entry(OdAplysdata).State = EntityState.Detached;
                        applyOddata.Status = "Applied";
                        applyOddata.ApplDate = DateTime.Now;
                        repo.Entry(applyOddata).State = EntityState.Modified;
                        repo.ApplyOddata.Update(applyOddata);

                        if (repo.SaveChanges() > 0)
                            return applyOddata;
                        else
                            errorMessage = "Registration failed.";
                        return null;
                    }

                }
                return applyOddata;
            }

            catch { throw; }

        }
    }
}

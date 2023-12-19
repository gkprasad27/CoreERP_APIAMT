using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SelfserviceHelpers
{
    public class OdApprovalHelper
    {
        public static List<ApplyOddata> GetOdApplDetailsList(string code)
        {
            using (ERPContext context = new ERPContext())
            {

                try
                {
                    List<TblEmployee> report = new List<TblEmployee>();
                    List<ApplyOddata> OdAplyDetails = new List<ApplyOddata>();
                    List<ApplyOddata> OdAply = new List<ApplyOddata>();
                    List<TblEmployee> empList = new List<TblEmployee>();
                    using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
                    {
                        List<TblEmployee> empLists = new List<TblEmployee>();
                        report = repo.TblEmployee.Where(x => x.ReportedBy == "").ToList();
                        empList = repo.TblEmployee.Where(x => x.ReportedBy == code).ToList();
                        empLists = repo.TblEmployee.Where(x => x.ApprovedBy == code).ToList();

                        foreach (var item in empList)
                        {
                            OdAplyDetails = context.ApplyOddata.Where(x => x.EmpCode == item.EmployeeCode && x.ReportId == code).Where(x => x.Status.Trim() == "Applied" || x.Status.Trim() == "Cancelled").ToList();
                            if (OdAplyDetails.Count != 0)
                            {
                                foreach (var query in OdAplyDetails)
                                {
                                    OdAply.Add(query);
                                }
                            }
                        }
                        foreach (var item in empLists)
                        {
                            if (item.ReportedBy == null || item.ReportedBy == "")
                            {
                                OdAplyDetails = context.ApplyOddata.Where(x => x.EmpCode == item.EmployeeCode && x.ApprovedId == code)
                                    .Where(x => (x.Status.Trim() == "Applied" || x.Status.Trim() == "Partially Approved")
                                || (x.Status.Trim() == "Cancelled" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                                if (OdAplyDetails.Count != 0)
                                {
                                    foreach (var query in OdAplyDetails)
                                    {
                                        OdAply.Add(query);
                                    }
                                }
                            }
                            else
                            {
                                OdAplyDetails = context.ApplyOddata.Where(x => x.EmpCode == item.EmployeeCode &&
                                (x.Status.Trim() == "Partially Approved" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                                if (OdAplyDetails.Count != 0)
                                {
                                    foreach (var query in OdAplyDetails)
                                    {
                                        OdAply.Add(query);
                                    }
                                }
                            }
                        }


                        return OdAply.Distinct().ToList();
                        // return repo.LeaveApplDetails.AsEnumerable().Where(m => m.Status == "Applied").ToList();
                    }
                }
                catch { throw; }
            }
        }

        public static List<ApplyOddata> GetOdApplDetailsList()
        {
            try
            {
                using (Repository<ApplyOddata> repo = new Repository<ApplyOddata>())
                {
                    return repo.ApplyOddata.AsEnumerable().ToList();
                }
            }
            catch { throw; }
        }

        public List<ApplyOddata> RegisterLeaveApprovalDetails(string code, ApplyOddata lop, List<ApplyOddata> applyod)
        {
            try
            {
                using (Repository<ApplyOddata> repo = new Repository<ApplyOddata>())
                {
                    string ApproveStatus = null;
                    foreach (var item in applyod)
                    {

                        var leaveapro = OdApprovalHelper.GetOdApplDetailsList().Where(x => x.Sno == item.Sno).FirstOrDefault();
                        if (lop.ApprBy == "Accept")
                        {
                            if (leaveapro.ReportId != null && leaveapro.Status == "Applied" && leaveapro.ReportId != "")
                            {
                                leaveapro.Status = "Partially Approved";
                            }
                            if (leaveapro.ReportId != null && leaveapro.Status == "Cancelled" && leaveapro.ReportId != "")
                            {
                                leaveapro.Status = "Partially Cancelled Approved";
                            }
                            else
                            {
                                if ((leaveapro.Status == "Partially Approved" || leaveapro.Status == "Applied") && leaveapro.ApprovedId == code)
                                {

                                    leaveapro.Status = "Approved";
                                    ApproveStatus = leaveapro.Status;
                                }
                                if ((leaveapro.Status == "Partially Cancelled Approved" || leaveapro.Status == "Cancelled") && leaveapro.ApprovedId == "RAJA")
                                {

                                    leaveapro.Status = "Cancelled";
                                    ApproveStatus = leaveapro.Status;
                                }
                                if (leaveapro.ApprovedId == code && (leaveapro.Status == "Applied" || ApproveStatus == "Approved" || ApproveStatus == "Cancelled"))
                                {
                                    leaveapro.ApprovedId = code;
                                    leaveapro.ApproveName = repo.TblEmployee.Where(x => x.EmployeeCode == leaveapro.ApprovedId).SingleOrDefault()?.EmployeeName;

                                }

                                if (leaveapro.Status == "Cancelled")
                                {
                                    leaveapro.Status = "Cancelled";
                                }

                                if (leaveapro.Status == "Partially Approved")
                                {
                                    leaveapro.Status = "Partially Approved";
                                }
                                if (leaveapro.Status == "Approved")
                                {
                                    leaveapro.Status = "Approved";
                                }
                            }
                        }
                        else

                        {
                            leaveapro.Status = "Rejected";
                            leaveapro.RejectedId = code;
                            leaveapro.RejectedName = repo.TblEmployee.Where(x => x.EmployeeCode == code).SingleOrDefault()?.EmployeeName;

                        }
                        repo.ApplyOddata.Update(leaveapro);
                    }

                    if (repo.SaveChanges() > 0)
                        return applyod.ToList();
                    return applyod.ToList(); ;
                }
            }
            catch { throw; }
        }

    }

}

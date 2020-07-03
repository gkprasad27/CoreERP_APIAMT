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
    public class AdvanceApprovalHelper
    {
        public static List<TblAdvance> GetAdvanceApplDetailsList(string code)
        {
            using (ERPContext context = new ERPContext())
            {

                try
                {
                    List<TblEmployee> report = new List<TblEmployee>();
                    List<TblAdvance> AdvanceAplyDetails = new List<TblAdvance>();
                    List<TblAdvance> OdAply = new List<TblAdvance>();
                    List<TblEmployee> empList = new List<TblEmployee>();
                    using (Repository<TblAdvance> repo = new Repository<TblAdvance>())
                    {
                        List<TblEmployee> empLists = new List<TblEmployee>();
                        report = repo.TblEmployee.Where(x => x.ReportedBy == "").ToList();
                        empList = repo.TblEmployee.Where(x => x.ReportedBy == code).ToList();
                        empLists = repo.TblEmployee.Where(x => x.ApprovedBy == code).ToList();

                        foreach (var item in empList)
                        {
                            AdvanceAplyDetails = context.TblAdvance.Where(x => x.EmployeeId == item.EmployeeCode && x.RecommendedBy == code).Where(x => x.Status.Trim() == "Applied" || x.Status.Trim() == "Cancelled").ToList();
                            if (AdvanceAplyDetails.Count != 0)
                            {
                                foreach (var query in AdvanceAplyDetails)
                                {
                                    OdAply.Add(query);
                                }
                            }
                        }
                        foreach (var item in empLists)
                        {
                            if (item.ReportedBy == null || item.ReportedBy == "")
                            {
                                AdvanceAplyDetails = context.TblAdvance.Where(x => x.EmployeeId == item.EmployeeCode && x.ApprovedBy == code)
                                    .Where(x => (x.Status.Trim() == "Applied" || x.Status.Trim() == "Partially Approved")
                                || (x.Status.Trim() == "Cancelled" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                                if (AdvanceAplyDetails.Count != 0)
                                {
                                    foreach (var query in AdvanceAplyDetails)
                                    {
                                        OdAply.Add(query);
                                    }
                                }
                            }
                            else
                            {
                                AdvanceAplyDetails = context.TblAdvance.Where(x => x.EmployeeId == item.EmployeeCode &&
                                (x.Status.Trim() == "Partially Approved" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                                if (AdvanceAplyDetails.Count != 0)
                                {
                                    foreach (var query in AdvanceAplyDetails)
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

        public static List<TblAdvance> GetAdvanceApplDetailsList()
        {
            try
            {
                using (Repository<TblAdvance> repo = new Repository<TblAdvance>())
                {
                    return repo.TblAdvance.AsEnumerable().ToList();
                }
            }
            catch { throw; }
        }


        public List<TblAdvance> RegisterAdvanceApprovalDetails(string code, ApplyOddata lop, List<TblAdvance> advance)
        {
            try
            {
                using (Repository<TblAdvance> repo = new Repository<TblAdvance>())
                {
                    string ApproveStatus = null;
                    foreach (var item in advance)
                    {

                        var leaveapro = AdvanceApprovalHelper.GetAdvanceApplDetailsList().Where(x => x.Id == item.Id).FirstOrDefault();
                        if (lop.ApprBy == "Accept")
                        {
                            if (leaveapro.RecommendedBy != null && leaveapro.Status == "Applied" && leaveapro.RecommendedBy != "")
                            {
                                leaveapro.Status = "Partially Approved";
                            }
                            if (leaveapro.RecommendedBy != null && leaveapro.Status == "Cancelled" && leaveapro.RecommendedBy != "")
                            {
                                leaveapro.Status = "Partially Cancelled Approved";
                            }
                            else
                            {
                                if ((leaveapro.Status == "Partially Approved" || leaveapro.Status == "Applied") && leaveapro.ApprovedBy == code)
                                {

                                    leaveapro.Status = "Approved";
                                    ApproveStatus = leaveapro.Status;
                                }
                                if ((leaveapro.Status == "Partially Cancelled Approved" || leaveapro.Status == "Cancelled") && leaveapro.ApprovedBy == "RAJA")
                                {

                                    leaveapro.Status = "Cancelled";
                                    ApproveStatus = leaveapro.Status;
                                }
                                if (leaveapro.ApprovedBy == code && (leaveapro.Status == "Applied" || ApproveStatus == "Approved" || ApproveStatus == "Cancelled"))
                                {
                                    leaveapro.ApprovedBy = code;
                                    //leaveapro.ApproveName = repo.TblEmployee.Where(x => x.EmployeeCode == leaveapro.ApprovedId).SingleOrDefault()?.EmployeeName;

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
                            //leaveapro.RejectedId = code;
                           // leaveapro.RejectedName = repo.TblEmployee.Where(x => x.EmployeeCode == code).SingleOrDefault()?.EmployeeName;

                        }
                        repo.TblAdvance.Update(leaveapro);
                    }

                    if (repo.SaveChanges() > 0)
                        return advance.ToList();
                    return advance.ToList(); ;
                }
            }
            catch { throw; }
        }
    }
}

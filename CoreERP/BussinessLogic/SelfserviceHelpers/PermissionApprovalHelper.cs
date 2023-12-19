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
  public class PermissionApprovalHelper
  {
        public static List<PermissionRequest> GetApplyPermissionRequestDetailsList(string code)
        {
            using (ERPContext context = new ERPContext())
            {

                try
                {
                    List<TblEmployee> report = new List<TblEmployee>();
                    List<PermissionRequest> PermissionRequestAplyDetails = new List<PermissionRequest>();
                    List<PermissionRequest> PermissionRequestAply = new List<PermissionRequest>();
                    List<TblEmployee> empList = new List<TblEmployee>();
                    using (Repository<TblAdvance> repo = new Repository<TblAdvance>())
                    {
                        List<TblEmployee> empLists = new List<TblEmployee>();
                        report = repo.TblEmployee.Where(x => x.ReportedBy == "").ToList();
                        empList = repo.TblEmployee.Where(x => x.ReportedBy == code).ToList();
                        empLists = repo.TblEmployee.Where(x => x.ApprovedBy == code).ToList();

                        foreach (var item in empList)
                        {
                            PermissionRequestAplyDetails = context.PermissionRequest.Where(x => x.EmpCode == item.EmployeeCode && x.ReportId == code).Where(x => x.Status.Trim() == "Applied" || x.Status.Trim() == "Cancelled").ToList();
                            if (PermissionRequestAplyDetails.Count != 0)
                            {
                                foreach (var query in PermissionRequestAplyDetails)
                                {
                                    PermissionRequestAply.Add(query);
                                }
                            }
                        }
                        foreach (var item in empLists)
                        {
                            if (item.ReportedBy == null || item.ReportedBy == "")
                            {
                                PermissionRequestAplyDetails = context.PermissionRequest.Where(x => x.EmpCode == item.EmployeeCode && x.ApprovedId == code)
                                    .Where(x => (x.Status.Trim() == "Applied" || x.Status.Trim() == "Partially Approved")
                                || (x.Status.Trim() == "Cancelled" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                                if (PermissionRequestAplyDetails.Count != 0)
                                {
                                    foreach (var query in PermissionRequestAplyDetails)
                                    {
                                        PermissionRequestAply.Add(query);
                                    }
                                }
                            }
                            else
                            {
                                PermissionRequestAplyDetails = context.PermissionRequest.Where(x => x.EmpCode == item.EmployeeCode &&
                                (x.Status.Trim() == "Partially Approved" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                                if (PermissionRequestAplyDetails.Count != 0)
                                {
                                    foreach (var query in PermissionRequestAplyDetails)
                                    {
                                        PermissionRequestAply.Add(query);
                                    }
                                }
                            }
                        }


                        return PermissionRequestAply.Distinct().ToList();
                    }
                }
                catch { throw; }
            }
        }


        public static List<PermissionRequest> GetPermissionRequestApplDetailsList()
        {
            try
            {
                using (Repository<PermissionRequest> repo = new Repository<PermissionRequest>())
                {
                    return repo.PermissionRequest.AsEnumerable().ToList();
                }
            }
            catch { throw; }
        }

        public List<PermissionRequest> RegisterPermissionApprovalDetails(string code, ApplyOddata lop, List<PermissionRequest> prrqst)
        {
            try
            {
                using (Repository<PermissionRequest> repo = new Repository<PermissionRequest>())
                {
                    string ApproveStatus = null;
                    foreach (var item in prrqst)
                    {

                        var permissionapprl = PermissionApprovalHelper.GetPermissionRequestApplDetailsList().Where(x => x.Id == item.Id).FirstOrDefault();
                        if (lop.ApprBy == "Accept")
                        {
                            if (permissionapprl.ReportId != null && permissionapprl.Status == "Applied" && permissionapprl.ReportId != "")
                            {
                                permissionapprl.Status = "Partially Approved";
                            }
                            if (permissionapprl.ReportId != null && permissionapprl.Status == "Cancelled" && permissionapprl.ReportId != "")
                            {
                                permissionapprl.Status = "Partially Cancelled Approved";
                            }
                            else
                            {
                                if ((permissionapprl.Status == "Partially Approved" || permissionapprl.Status == "Applied") && permissionapprl.ApprovedId == code)
                                {

                                    permissionapprl.Status = "Approved";
                                    ApproveStatus = permissionapprl.Status;
                                }
                                if ((permissionapprl.Status == "Partially Cancelled Approved" || permissionapprl.Status == "Cancelled") && permissionapprl.ApprovedId == "RAJA")
                                {

                                    permissionapprl.Status = "Cancelled";
                                    ApproveStatus = permissionapprl.Status;
                                }
                                if (permissionapprl.ApprovedId == code && (permissionapprl.Status == "Applied" || ApproveStatus == "Approved" || ApproveStatus == "Cancelled"))
                                {
                                    permissionapprl.ApprovedId = code;
                                    permissionapprl.ApprovedName = repo.TblEmployee.Where(x => x.EmployeeCode == permissionapprl.ApprovedId).SingleOrDefault()?.EmployeeName;

                                }

                                if (permissionapprl.Status == "Cancelled")
                                {
                                    permissionapprl.Status = "Cancelled";
                                }

                                if (permissionapprl.Status == "Partially Approved")
                                {
                                    permissionapprl.Status = "Partially Approved";
                                }
                                if (permissionapprl.Status == "Approved")
                                {
                                    permissionapprl.Status = "Approved";
                                }
                            }
                        }
                        else

                        {
                            permissionapprl.Status = "Rejected";
                            permissionapprl.Reason = item.Reason;
                            permissionapprl.RejectedId = code;
                            permissionapprl.RejectedName = repo.TblEmployee.Where(x => x.EmployeeCode == code).SingleOrDefault()?.EmployeeName;

                        }
                        repo.PermissionRequest.Update(permissionapprl);
                    }

                    if (repo.SaveChanges() > 0)
                        return prrqst.ToList();
                    return prrqst.ToList(); ;
                }
            }
            catch { throw; }
        }
    }
}

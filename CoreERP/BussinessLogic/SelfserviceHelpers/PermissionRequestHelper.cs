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
  public class PermissionRequestHelper
  {
       

        public static List<PermissionRequest> GetPermissionApplDetailsList(string code)
        {
            try
            {
                using (Repository<PermissionRequest> repo = new Repository<PermissionRequest>())
                {
                    if (code.ToLower() == "admin")
                    {
                        return repo.PermissionRequest.ToList();

                    }
                    else
                        return repo.PermissionRequest.Where(x => x.EmpCode == code).ToList();
                }
            }
            catch { throw; }
        }

        public static PermissionRequest RegisterPermissionApplDetails(PermissionRequest permissionRequest)
    {
      try
      {
                using Repository<PermissionRequest> repo = new Repository<PermissionRequest>();
                var empdata = repo.TblEmployee.Where(x => x.EmployeeCode == permissionRequest.EmpCode).FirstOrDefault();
                permissionRequest.Status = "Applied";
                permissionRequest.PermissionDate = DateTime.Now;
                permissionRequest.ReportId = empdata.ReportedBy;
                permissionRequest.ReportName = repo.TblEmployee.Where(x => x.EmployeeCode == permissionRequest.ReportId).SingleOrDefault()?.EmployeeName;
                permissionRequest.ApprovedId = empdata.ApprovedBy;
                permissionRequest.ApprovedName = repo.TblEmployee.Where(x => x.EmployeeCode == permissionRequest.ApprovedId).SingleOrDefault()?.EmployeeName;
                repo.PermissionRequest.Add(permissionRequest);
                if (repo.SaveChanges() > 0)
                    return permissionRequest;
                return null;
            }
      catch { throw; }
    }

        public static PermissionRequest UpdatePermissionapplying(PermissionRequest permission, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                
                using (Repository<PermissionRequest> repo = new Repository<PermissionRequest>())
                {
                    var PRAplysdata = repo.PermissionRequest.Where(x => x.Id == permission.Id).FirstOrDefault();
                    if (PRAplysdata.Id > 0)
                    {
                        repo.Entry(PRAplysdata).State = EntityState.Detached;
                        permission.Status = "Applied";
                        permission.PermissionDate = DateTime.Now;
                        repo.Entry(permission).State = EntityState.Modified;
                        repo.PermissionRequest.Update(permission);

                        if (repo.SaveChanges() > 0)
                            return permission;
                        else
                            errorMessage = "Registration failed.";
                        return null;
                    }

                }
                return permission;
            }

            catch { throw; }

        }
    }
}

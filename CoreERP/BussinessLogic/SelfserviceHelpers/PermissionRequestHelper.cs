using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SelfserviceHelpers
{
  public class PermissionRequestHelper
  {
    public static List<PermissionRequest> GetPermissionApplDetailsList()
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

    public static PermissionRequest RegisterPermissionApplDetails(PermissionRequest permissionRequest)
    {
      try
      {
        using (Repository<PermissionRequest> repo = new Repository<PermissionRequest>())
        {
          permissionRequest.Status = "Applied";
          permissionRequest.PermissionDate = DateTime.Now;
          repo.PermissionRequest.Add(permissionRequest);
          if (repo.SaveChanges() > 0)
            return permissionRequest;
          return null;
        }
      }
      catch { throw; }
    }
  }
}

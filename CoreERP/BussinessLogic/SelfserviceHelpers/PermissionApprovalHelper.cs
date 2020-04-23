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
    public static List<PermissionRequest> GetApplyPermissionRequestDetailsList()
    {
      try
      {
        List<Employees> report = new List<Employees>();
        List<Employees> empList = new List<Employees>();
        List<Employees> empList1 = new List<Employees>();
        List<PermissionRequest> ApplyPermissionRequestdataDetails = new List<PermissionRequest>();
        List<PermissionRequest> ApplyPermissionRequestdata = new List<PermissionRequest>();

                using Repository<PermissionRequest> repo = new Repository<PermissionRequest>();
                List<Employees> empLists = new List<Employees>();
                //foreach (var item in empList)
                //{
                //    repo.PermissionRequest.AsEnumerable().Where(x => x.EmpCode == item.Code && x.ReportId == "RAMA").Where(x => x.Status.Trim() == "Applied" || x.Status.Trim() == "Cancelled").ToList();
                //    if (ApplyPermissionRequestdataDetails.Count != 0)
                //    {
                //        foreach (var query in ApplyPermissionRequestdataDetails)
                //        {
                //            ApplyPermissionRequestdata.Add(query);
                //        }
                //    }
                //}
                //foreach (var item in empList1)
                //{
                //    if (item.ReportingTo == null || item.ReportingTo == "")
                //    {
                //        repo.PermissionRequest.AsEnumerable().Where(x => x.EmpCode == item.Code && x.ApprovedId == "RAJA").Where(x => (x.Status.Trim() == "Applied" || x.Status.Trim() == "Partially Approved") || (x.Status.Trim() == "Cancelled" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                //        if (ApplyPermissionRequestdataDetails.Count != 0)
                //        {
                //            foreach (var query in ApplyPermissionRequestdataDetails)
                //            {
                //                ApplyPermissionRequestdata.Add(query);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        repo.PermissionRequest.AsEnumerable().Where(x => x.EmpCode == item.Code && (x.Status.Trim() == "Partially Approved" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                //        if (ApplyPermissionRequestdataDetails.Count != 0)
                //        {
                //            foreach (var query in ApplyPermissionRequestdataDetails)
                //            {
                //                ApplyPermissionRequestdata.Add(query);
                //            }
                //        }
                //    }
                //}
                //return repo.PermissionRequest.AsEnumerable().ToList();

                return null;
            }
      catch { throw; }
    }
  }
}

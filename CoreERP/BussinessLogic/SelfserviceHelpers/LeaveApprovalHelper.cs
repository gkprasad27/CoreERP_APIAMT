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
  public class LeaveApprovalHelper
  {
   
    //public static List<LeaveApplDetails> GetLeaveApplDetailsList()
    //{
    //  try
    //  {
    //    List<Employees> report = new List<Employees>();
    //    List<Employees> empList = new List<Employees>();
    //    List<Employees> empList1 = new List<Employees>();
    //    List<LeaveApplDetails> LeaveAplyDetails = new List<LeaveApplDetails>();
    //    List<LeaveApplDetails> LeaveAply = new List<LeaveApplDetails>();

    //    using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
    //    {
    //      List<Employees> empLists = new List<Employees>();
    //      foreach (var item in empList)
    //      {
    //        repo.LeaveApplDetails.AsEnumerable().Where(x => x.EmpCode == item.Code && x.RecommendedId == "RAMA").Where(x => x.Status.Trim() == "Applied" || x.Status.Trim() == "Cancelled").ToList();
    //        if (LeaveAplyDetails.Count != 0)
    //        {
    //          foreach (var query in LeaveAplyDetails)
    //          {
    //            LeaveAply.Add(query);
    //          }
    //        }
    //      }
    //      foreach (var item in empList1)
    //      {
    //        if (item.ReportingTo == null || item.ReportingTo == "")
    //        {
    //          repo.LeaveApplDetails.AsEnumerable().Where(x => x.EmpCode == item.Code && x.ApprovedId =="RAJA").Where(x => (x.Status.Trim() == "Applied" || x.Status.Trim() == "Partially Approved") || (x.Status.Trim() == "Cancelled" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
    //          if (LeaveAplyDetails.Count != 0)
    //          {
    //            foreach (var query in LeaveAplyDetails)
    //            {
    //              LeaveAply.Add(query);
    //            }
    //          }
    //        }
    //        else
    //        {
    //          repo.LeaveApplDetails.AsEnumerable().Where(x => x.EmpCode == item.Code && (x.Status.Trim() == "Partially Approved" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
    //          if (LeaveAplyDetails.Count != 0)
    //          {
    //            foreach (var query in LeaveAplyDetails)
    //            {
    //              LeaveAply.Add(query);
    //            }
    //          }
    //        }
    //      }
    //      //return LeaveAply.ToList();
    //      return repo.LeaveApplDetails.AsEnumerable().Where(m => m.Status == "Applied").ToList();
    //    }
    //  }
    //  catch { throw; }
    //}


    public static LeaveApplDetails RegisterLeaveApprovalDetails(LeaveApplDetails  leaveAprovalA)
    {
      try
      {
        using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
        {
          repo.LeaveApplDetails.Add(leaveAprovalA);
          if (repo.SaveChanges() > 0)
            return leaveAprovalA;
          return null;
        }
      }
      catch { throw; }
    }
  }
}

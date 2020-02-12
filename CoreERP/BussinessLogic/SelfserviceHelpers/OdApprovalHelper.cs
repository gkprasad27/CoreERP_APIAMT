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
    public static List<ApplyOddata> GetApplyOddataDetailsList()
    {
      try
      {
        List<Employees> report = new List<Employees>();
        List<Employees> empList = new List<Employees>();
        List<Employees> empList1 = new List<Employees>();
        List<ApplyOddata> ApplyOddataDetails = new List<ApplyOddata>();
        List<ApplyOddata> ApplyOddata = new List<ApplyOddata>();

        using (Repository<ApplyOddata> repo = new Repository<ApplyOddata>())
        {
          List<Employees> empLists = new List<Employees>();
          foreach (var item in empList)
          {
            repo.ApplyOddata.AsEnumerable().Where(x => x.EmpCode == item.Code && x.ReportId == "RAMA").Where(x => x.Status.Trim() == "Applied" || x.Status.Trim() == "Cancelled").ToList();
            if (ApplyOddataDetails.Count != 0)
            {
              foreach (var query in ApplyOddataDetails)
              {
                ApplyOddata.Add(query);
              }
            }
          }
          foreach (var item in empList1)
          {
            if (item.ReportingTo == null || item.ReportingTo == "")
            {
              repo.ApplyOddata.AsEnumerable().Where(x => x.EmpCode == item.Code && x.ApprovedId == "RAJA").Where(x => (x.Status.Trim() == "Applied" || x.Status.Trim() == "Partially Approved") || (x.Status.Trim() == "Cancelled" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
              if (ApplyOddataDetails.Count != 0)
              {
                foreach (var query in ApplyOddataDetails)
                {
                  ApplyOddata.Add(query);
                }
              }
            }
            else
            {
              repo.ApplyOddata.AsEnumerable().Where(x => x.EmpCode == item.Code && (x.Status.Trim() == "Partially Approved" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
              if (ApplyOddataDetails.Count != 0)
              {
                foreach (var query in ApplyOddataDetails)
                {
                  ApplyOddata.Add(query);
                }
              }
            }
          }
          //return LeaveAply.ToList();
          return repo.ApplyOddata.AsEnumerable().Where(m => m.Status == "Applied").ToList();
        }
      }
      catch { throw; }
    }
  }
}

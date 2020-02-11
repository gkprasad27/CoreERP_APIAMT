using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SelfserviceHelpers
{
  public class LeaveRequestHelper
  {
    public static List<Employees> GetEmployeesList()
    {
      try
      {
        IList<Employees> empList = new List<Employees>() {
                new Employees(){ Code="1", Name="Bill",Active="Y"}
                //new Employees(){ Code="2", Name="Steve",Active="Y"},
                //new Employees(){ Code="3", Name="Ram",Active="Y"},
                //new Employees(){ Code="4", Name="Moin",Active="Y"}
            };
        return empList.ToList();
      }
      catch { throw; }
    }


    public static List<LeaveApplDetails> GetLeaveApplDetailsList()
    {
      try
      {
        using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
        {
          return repo.LeaveApplDetails.AsEnumerable().ToList();
        }
      }
      catch { throw; }
    }

    public static LeaveApplDetails RegisterLeaveApplDetails(LeaveApplDetails leaveApplDetails)
    {
      try
      {
        using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
        {
          leaveApplDetails.Status = "Applied";
          leaveApplDetails.ApplDate = DateTime.Now;
          repo.LeaveApplDetails.Add(leaveApplDetails);
          if (repo.SaveChanges() > 0)
            return leaveApplDetails;
          return null;
        }
      }
      catch { throw; }
    }
  }
}

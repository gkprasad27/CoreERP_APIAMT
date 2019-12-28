using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
  public class LeaveTypeHelper
  {
    private static Repository<LeaveTypes> _repo = null;
    private static Repository<LeaveTypes> repo
    {
      get
      {
        if (_repo == null)
          _repo = new Repository<LeaveTypes>();
        return _repo;
      }
    }

    public static List<LeaveTypes> GetLeaveTypeList()
    {
      try
      {
        return repo.LeaveTypes.Select(p => p).ToList();
      }
      catch { throw; }
    }



    public static int RegisterLeaveType(LeaveTypes leaveType)
    {
      try
      {
        repo.LeaveTypes.Add(leaveType);
        return repo.SaveChanges();
      }
      catch { throw; }
    }



    public static int UpdateLeaveType(LeaveTypes leaveType)
    {
      try
      {
        repo.LeaveTypes.Update(leaveType);
        return repo.SaveChanges();
      }
      catch { throw; }
    }



    public static int DeleteLeaveType(string leaveTypeCode)
    {
      try
      {
        var leavetyp = repo.LeaveTypes.Where(l => l.LeaveCode == leaveTypeCode).FirstOrDefault();
        repo.LeaveTypes.Remove(leavetyp);
        return repo.SaveChanges();
      }
      catch { throw; }
    }
  }
}

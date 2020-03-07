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

    public static List<LeaveTypes> GetListOfLeaveTypes()
    {
      try
      {
        using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
        {
          return repo.LeaveTypes.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
        }
      }
      catch { throw; }
    }


    public static LeaveTypes GetLeaveTypes(string compCode)
    {
      try
      {
        using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
        {
          return repo.LeaveTypes.AsEnumerable()
                     .Where(x => x.CompanyCode.Equals(compCode))
                               .FirstOrDefault();
        }
      }
      catch { throw; }
    }

    
    public static List<LeaveTypes> GetList(string code)
    {
      try
      {
        using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
        {
          return repo.LeaveTypes
                     .Where(x => x.LeaveCode == code)
                     .ToList();
        }
      }
      catch { throw; }
    }

    public static List<LeaveTypes> GetList()
    {
      try
      {
        using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
        {
          return repo.LeaveTypes.AsEnumerable().Where(x => x.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
        }
      }
      catch { throw; }
    }

    public static LeaveTypes Register(LeaveTypes leavetype)
    {
      try
      {
        using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
        {
          leavetype.Active = "Y";
          repo.LeaveTypes.Add(leavetype);
          if (repo.SaveChanges() > 0)
            return leavetype;

          return null;
        }
      }
      catch { throw; }
    }

    public static LeaveTypes Update(LeaveTypes leavetype)
    {
      try
      {
        using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
        {
          repo.LeaveTypes.Update(leavetype);
          if (repo.SaveChanges() > 0)
            return leavetype;

          return null;
        }
      }
      catch { throw; }
    }

    public static LeaveTypes DeleteLeaveTypes(string code)
    {
      try
      {
        using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
        {
          var ltype = repo.LeaveTypes.Where(x => x.LeaveCode == code).FirstOrDefault();
          ltype.Active = "N";
          repo.LeaveTypes.Update(ltype);
          if (repo.SaveChanges() > 0)
            return ltype;

          return null;
        }
      }
      catch { throw; }
    }
  }
}

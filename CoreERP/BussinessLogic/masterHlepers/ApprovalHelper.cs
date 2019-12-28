using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
  public class ApprovalHelper
  {
    private static Repository<ApprovalType> _repo = null;
    private static Repository<ApprovalType> repo
    {
      get
      {
        if (_repo == null)
          _repo = new Repository<ApprovalType>();
        return _repo;
      }
    }
    public static List<ApprovalType> GetListOfApprovals()
    {
      try
      {
        return repo.GetAll().ToList();
      }
      catch { throw; }
    }

    public static int RegisterApprovalType(ApprovalType approvalType)
    {
      try
      {
        repo.ApprovalType.Add(approvalType);
        return repo.SaveChanges();
      }
      catch { throw; }
    }

    public static int UpdateApprovalType(ApprovalType approvalType)
    {
      try
      {
        repo.ApprovalType.Update(approvalType);
        return repo.SaveChanges();
      }
      catch { throw; }
    }

    public static int DeleteApprovalType(int approvalTypeCode)
    {
      try
      {
        var apprtype = repo.ApprovalType.Where(a => a.ApprovalId == approvalTypeCode).FirstOrDefault();
        repo.ApprovalType.Remove(apprtype);
        return repo.SaveChanges();
      }
      catch { throw; }
    }
  }
}

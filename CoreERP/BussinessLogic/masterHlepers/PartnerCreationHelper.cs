using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
  public class PartnerCreationHelper
  {
    private static Repository<PartnerCreation> _repo = null;
    private static Repository<PartnerCreation> repo
    {
      get
      {
        if (_repo == null)
          _repo = new Repository<PartnerCreation>();
        return _repo;
      }
    }

    public static List<PartnerCreation> GetList()
    {
      try
      {
        return repo.PartnerCreation.ToList();
      }
      catch { throw; }
    }

    public static int RegisterPartnerCreation(PartnerCreation partnerCreation)
    {
      try
      {
        var record = ((from prtnrcrt in repo.PartnerCreation select prtnrcrt.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
   
        if (record != 0)
        {
          partnerCreation.Code = (record + 1).ToString();
        }
        else
          partnerCreation.Code = "1";

        repo.PartnerCreation.Add(partnerCreation);
        return repo.SaveChanges();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static int UpdatePartnerCreation(PartnerCreation partnerCreation)
    {
      try
      {
        repo.PartnerCreation.Update(partnerCreation);
        return repo.SaveChanges();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static int DeletePartnerCreation(string code)
    {
      try
      {
        var partnerCreation = repo.PartnerCreation.Where(x => x.Code == code).FirstOrDefault();
        repo.PartnerCreation.Remove(partnerCreation);
        return repo.SaveChanges();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

  }
}

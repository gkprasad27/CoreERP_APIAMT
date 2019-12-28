using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
  public class SegmentHelper
  {
    private static Repository<Segment> _repo = null;
    private static Repository<Segment> repo
    {
      get
      {
        if (_repo == null)
          _repo = new Repository<Segment>();
        return _repo;
      }
    }

    public static List<Segment> GetSegmentList()
    {
      try
      {
        return repo.Segment.Select(s => s).ToList();
      }
      catch { throw; }
    }

    public static int RegisterSegment(Segment segment)
    {
      try
      {
        repo.Segment.Add(segment);
        return repo.SaveChanges();
      }
      catch { throw; }
    }

    public static int UpdateSegment(Segment segment)
    {
      try
      {
        repo.Segment.Update(segment);
        return repo.SaveChanges();
      }
      catch { throw; }
    }


    public static int DeleteSegment(string segmentId)
    {
      try
      {
        var segment = repo.Segment.Where(s => s.Id == segmentId).FirstOrDefault();
        repo.Segment.Remove(segment);
        return repo.SaveChanges();
      }
      catch { throw; }
    }
  }
}

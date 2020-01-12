using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class SegmentHelper
    {
        public static List<Segment> GetSegmentList()
        {
            try
            {
                using (Repository<Segment> repo = new Repository<Segment>())
                {
                    return repo.Segment.AsEnumerable().Where(s => s.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }

        public static bool IsSegmentIDExists(string ID)
        {
            try
            {
                using (Repository<Segment> repo = new Repository<Segment>())
                {
                    return repo.Segment
                               .AsEnumerable()
                               .Where(s => s.Id == ID)
                               .Count() > 0;
                }
            }
            catch { throw; }
        }

        public static Segment RegisterSegment(Segment segment)
        {
            try
            {
                using (Repository<Segment> repo = new Repository<Segment>())
                {
                    segment.Active = "Y";
                    repo.Segment.Add(segment);
                    if (repo.SaveChanges() > 0)
                        return segment;

                    return null;
                }
            }
            catch { throw; }
        }

        public static Segment UpdateSegment(Segment segment)
        {
            try
            {
                using (Repository<Segment> repo = new Repository<Segment>())
                {
                    repo.Segment.Update(segment);
                    if (repo.SaveChanges() > 0)
                        return segment;

                    return null;
                }
            }
            catch { throw; }
        }


        public static Segment DeleteSegment(int seqID)
        {
            try
            {
                using (Repository<Segment> repo = new Repository<Segment>())
                {
                    var segment = repo.Segment.Where(s => s.SeqId == seqID).FirstOrDefault();
                    segment.Active = "N";
                    repo.Segment.Update(segment);
                    if (repo.SaveChanges() > 0)
                        return segment;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
